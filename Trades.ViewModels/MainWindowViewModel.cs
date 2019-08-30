using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Trades.Helpers;
using Trades.Models;

namespace Trades.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        ILogger logger = new Logger(typeof(MainWindowViewModel));

        public MainWindowViewModel()
        {
            Title = "Trades Exercise";
            logger.LogInfoMessage("\nApplication Started.");
        }

        #region Properties
        string filePath;
        public string FilePath
        {
            get { return filePath; }
            set
            {
                SetProperty(ref filePath, value);
                CalcBtnVisible = false;
                CalcGridVisible = false;
                LoadBtnVisible = true;
                TradesGridVisible = false;
                ErrorMsg = "";
                SuccMsg = "";
            }
        }

        List<Trade> tradesList;
        public List<Trade> TradesList
        {
            get { return tradesList; }
            set { SetProperty(ref tradesList, value); }
        }

        List<TradeResult> tradesResult;
        public List<TradeResult> TradesResult
        {
            get { return tradesResult; }
            set { SetProperty(ref tradesResult, value); }
        }

        string errorMsg;
        public string ErrorMsg
        {
            get { return errorMsg; }
            set { SetProperty(ref errorMsg, value); }
        }

        string succMsg;
        public string SuccMsg
        {
            get { return succMsg; }
            set { SetProperty(ref succMsg, value); }
        }

        bool loadBtnVisible;
        public bool LoadBtnVisible
        {
            get { return loadBtnVisible; }
            set { SetProperty(ref loadBtnVisible, value); }
        }

        bool tradesGridVisible;
        public bool TradesGridVisible
        {
            get { return tradesGridVisible; }
            set { SetProperty(ref tradesGridVisible, value); }
        }

        bool calcBtnVisible;
        public bool CalcBtnVisible
        {
            get { return calcBtnVisible; }
            set { SetProperty(ref calcBtnVisible, value); }
        }

        bool calcGridVisible;
        public bool CalcGridVisible
        {
            get { return calcGridVisible; }
            set { SetProperty(ref calcGridVisible, value); }
        }

        public ICommand OpenFileDialogCommand
        {
            get { return new DelegateCommand(OpenFileDialog); }
        }

        public ICommand SaveFileDialogCommand
        {
            get { return new DelegateCommand(SaveFileDialog); }
        }

        public ICommand LoadFileDialogCommand
        {
            get { return new DelegateCommand(LoadFileDialog); }
        }

        public ICommand CalculateTradesResultCommand
        {
            get { return new DelegateCommand(CalculateTradesResult); }
        }

        public ICommand OpenLogFileCommand
        {
            get { return new DelegateCommand(OpenLogFile); }
        }
        #endregion

        #region Commands
        private void OpenFileDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";

            if (dlg.ShowDialog() == true)
            {
                FilePath = dlg.FileName;
                logger.LogInfoMessage($"File is choosen: {FilePath}");
            }

        }

        private void SaveFileDialog()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files (*.csv)|*.csv";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    TradesCSVHelper tchlp = new TradesCSVHelper();
                    tchlp.ConvertToCSV(TradesResult, dlg.FileName);
                    logger.LogInfoMessage($"CSV fild saved to: {dlg.FileName}");
                    SuccMsg = "CSV file is saved successfully";
                }
                catch (Exception ex)
                {
                    ErrorMsg = "An Exception has occured while saving. check server.log file for more detail. ";
                    logger.LogException(ex);
                }
            }

        }

        private void LoadFileDialog()
        {
            TradesXMLHelper thlp = new TradesXMLHelper();
            try
            {
                if (thlp.IsGoodTradeXmlFile(filePath))
                {
                    try
                    {
                        TradesList = thlp.GetTradesFromXmlFile(FilePath).Trades;
                        logger.LogInfoMessage($"file loaded successfully");
                        CalcBtnVisible = true;
                        TradesGridVisible = true;
                    }
                    catch (Exception ex)
                    {

                        ErrorMsg = "An Exception has occured. check server.log file for more detail. ";
                        logger.LogException(ex);
                    }
                }
                else
                {
                    ErrorMsg = "This XML file is not a good trade file.";
                    logger.LogError($"This choosen XML file is not a good trade file.");
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = "Please, make sure path is right.";
                logger.LogException(ex);
            }

        }

        private void CalculateTradesResult()
        {
            TradeLogicHelper tlhlp = new TradeLogicHelper();
            //check if there is more than one item with same trade id
            if (tlhlp.CheckNotSameTradeId(TradesList))
            {
                //here to check if there are any problems discovered after grouping
                //ex: some of the groups doesn't all have the same limits
                //ex: some of the groups doesn't all have the same number of trades....
                List<TradingGroupStatus> tgStatuses = tlhlp.CheckGroupsError(TradesList);
                bool errorsFound = false;
                foreach (var item in tgStatuses)
                {
                    if (!item.HasNoErrors)
                    {
                        logger.LogError(item.ErrorMessage);
                        errorsFound = true;
                    }
                }
                if (!errorsFound)
                {
                    TradesResult = tlhlp.CalculateResult(TradesList);
                    logger.LogInfoMessage($"Calculation Done. No errors found.");
                    CalcGridVisible = true;
                }
                else
                {
                    ErrorMsg = "The data is not good. Check server.log for detailed info.";
                }
            }
            else
            {
                ErrorMsg = "Two items has the same TradeId.";
                logger.LogError($"Two items has the same TradeId. remove one of them.");
            }

        }

        private void OpenLogFile()
        {
            try
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/server.log");
            }
            catch (Exception)
            {
                ErrorMsg = "Please check if server.log file exists.";
                logger.LogError($"This choosen XML file is not a good trade file.");
            }
        }
        #endregion
    }
}
