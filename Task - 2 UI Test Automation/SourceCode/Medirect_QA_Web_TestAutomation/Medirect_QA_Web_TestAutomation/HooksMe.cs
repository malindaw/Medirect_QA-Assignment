using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Medirect_QA_Web_TestAutomation.Drivers;
using System.Security.Cryptography;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;

namespace Medirect_QA_Web_TestAutomation
{
    [Binding]
    public sealed class HooksMe
    {
        /* private static ExtentTest featureName;
         private static ExtentTest Scenario;
         private static ExtentReports extent;*/

        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario,step;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");

        

       /* [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            //Scenario = extent.CreateTest<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }*/

       /* [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            
        }*/

        [BeforeTestRun]
        public static void initializeReport()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
            /*var htmlReporter = new ExtentHtmlReporter(@"C:\General\Medirect - QA Assigment\Task - 2 UI Test Automation\SourceCode\Medirect_QA_Web_TestAutomation\Medirect_QA_Web_TestAutomation\ExtentReport.html");
            //htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);*/
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title); 
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
           
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }
        [BeforeStep]
        public static void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void tearDownReport()
        {
            extent.Flush();
        }
        

        /*[AfterStep]
        public void insertReportingSteps()
        {
            Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        }*/

        [AfterScenario]
        public void AfterScenario()
        {
            BaseTest.driver.Quit();
        }
    }
}