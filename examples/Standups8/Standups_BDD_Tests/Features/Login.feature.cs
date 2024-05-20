﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:1.0.0.0
//      Reqnroll Generator Version:1.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Standups_BDD_Tests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("User Logins")]
    [NUnit.Framework.CategoryAttribute("Scot")]
    public partial class UserLoginsFeature
    {
        
        private Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Scot"};
        
#line 1 "Login.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, NUnit.Framework.TestContext.CurrentContext.WorkerId);
            Reqnroll.FeatureInfo featureInfo = new Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "User Logins", @"**As a registered user I would like to be able to login so I may be able to have a customized experience.**

This feature ensures that users who have previously registered can successfully login and see a personalized message
that confirms they are recognized by the application and logged in.  It also *defines* a set of seeded users for 
future software test engineers to use when performing other kinds of tests.

The steps we define here can be re-used when testing the *register* feature.

To generate living documentation, create a Documentation folder and then run one of these from the project dir: 
    `livingdoc test-assembly -t bin\Debug\net7.0\TestExecution.json -o Documentation bin\Debug\net7.0\Standups_BDD_Tests.dll`
    `livingdoc feature-folder -t bin\Debug\net7.0\TestExecution.json -o Documentation .`", ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 15
#line hidden
            Reqnroll.Table table2 = new Reqnroll.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table2.AddRow(new string[] {
                        "TaliaK",
                        "knott@example.com",
                        "Talia",
                        "Knott",
                        "Hello123#"});
            table2.AddRow(new string[] {
                        "ZaydenC",
                        "clark@example.com",
                        "Zayden",
                        "Clark",
                        "Hello123#"});
            table2.AddRow(new string[] {
                        "DavilaH",
                        "hareem@example.com",
                        "Hareem",
                        "Davila",
                        "Hello123#"});
            table2.AddRow(new string[] {
                        "KrzysztofP",
                        "krzysztof@example.com",
                        "Krzysztof",
                        "Ponce",
                        "Hello123#"});
#line 16
 await testRunner.GivenAsync("the following users exist", ((string)(null)), table2, "Given ");
#line hidden
            Reqnroll.Table table3 = new Reqnroll.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table3.AddRow(new string[] {
                        "AndreC",
                        "colea@example.com",
                        "Andre",
                        "Cole",
                        "0a9dfi3.a"});
            table3.AddRow(new string[] {
                        "JoannaV",
                        "valdezJ@example.com",
                        "Joanna",
                        "Valdez",
                        "d9u(*dsF4"});
#line 22
 await testRunner.AndAsync("the following users do not exist", ((string)(null)), table3, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Existing user can login")]
        [NUnit.Framework.CategoryAttribute("LoggedIn")]
        [NUnit.Framework.TestCaseAttribute("Talia", "Home", null)]
        [NUnit.Framework.TestCaseAttribute("Zayden", "Home", null)]
        [NUnit.Framework.TestCaseAttribute("Hareem", "Home", null)]
        [NUnit.Framework.TestCaseAttribute("Krzysztof", "Home", null)]
        public async System.Threading.Tasks.Task ExistingUserCanLogin(string firstName, string page, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "LoggedIn"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("Page", page);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("Existing user can login", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 15
await this.FeatureBackgroundAsync();
#line hidden
#line 29
 await testRunner.GivenAsync(string.Format("I am a user with first name \'{0}\'", firstName), ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 30
 await testRunner.WhenAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 31
 await testRunner.ThenAsync(string.Format("I am redirected to the \'{0}\' page", page), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
#line 32
   await testRunner.AndAsync("I can see a personalized message in the navbar that includes my email", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Non-user cannot login")]
        [NUnit.Framework.TestCaseAttribute("Andre", null)]
        [NUnit.Framework.TestCaseAttribute("Joanna", null)]
        public async System.Threading.Tasks.Task Non_UserCannotLogin(string firstName, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("Non-user cannot login", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 40
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 15
await this.FeatureBackgroundAsync();
#line hidden
#line 41
 await testRunner.GivenAsync(string.Format("I am a user with first name \'{0}\'", firstName), ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 42
 await testRunner.WhenAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 43
 await testRunner.ThenAsync("I can see a login error message", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("We can save cookies")]
        [NUnit.Framework.CategoryAttribute("support")]
        public async System.Threading.Tasks.Task WeCanSaveCookies()
        {
            string[] tagsOfScenario = new string[] {
                    "support"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("We can save cookies", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 15
await this.FeatureBackgroundAsync();
#line hidden
#line 52
 await testRunner.GivenAsync("I am a user with first name \'Talia\'", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 53
 await testRunner.WhenAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 54
 await testRunner.ThenAsync("I can save cookies", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("We can log in with only a cookie")]
        [NUnit.Framework.CategoryAttribute("support")]
        public async System.Threading.Tasks.Task WeCanLogInWithOnlyACookie()
        {
            string[] tagsOfScenario = new string[] {
                    "support"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("We can log in with only a cookie", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 57
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 15
await this.FeatureBackgroundAsync();
#line hidden
#line 58
 await testRunner.GivenAsync("I am a user with first name \'Talia\'", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 60
  await testRunner.AndAsync("I am on the \"Home\" page", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 61
 await testRunner.WhenAsync("I load previously saved cookies", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 62
  await testRunner.AndAsync("I am on the \"Home\" page", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 63
 await testRunner.ThenAsync("I can see a personalized message in the navbar that includes my email", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion