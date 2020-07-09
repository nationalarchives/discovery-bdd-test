﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SSOTests.FeatureFiles
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Register page")]
    public partial class RegisterPageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "RegisterPageOnTest.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Register page", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
#line 4
 testRunner.Given("I am on Registration page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("click register with empty fields")]
        public virtual void ClickRegisterWithEmptyFields()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("click register with empty fields", "Here we are checking all the validation messages", tagsOfScenario, argumentsOfScenario);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 8
 testRunner.When("I click on Register without entering anything", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then("I can see validation messages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("register with invalid mismatch email and  password")]
        [NUnit.Framework.TestCaseAttribute("Test", "tnadiscovery100@gmail.com", "tnadiscovery100@gmaillllll.com", "Discovery1234", "Discovery1234", "The email address and confirmation email address do not match.", "The password and confirmation password do not match.", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "discovery12345@gmail.com", "discovery12345@gmail.com", "Test1234567", "Test1234", "The email address and confirmation email address do not match.", "The password and confirmation password do not match.", null)]
        public virtual void RegisterWithInvalidMismatchEmailAndPassword(string name, string email, string confirmEmail, string pswd, string confirmPswd, string emailValidationMessage, string pswdValidationMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("confirmEmail", confirmEmail);
            argumentsOfScenario.Add("pswd", pswd);
            argumentsOfScenario.Add("confirmPswd", confirmPswd);
            argumentsOfScenario.Add("emailValidationMessage", emailValidationMessage);
            argumentsOfScenario.Add("pswdValidationMessage", pswdValidationMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("register with invalid mismatch email and  password", null, tagsOfScenario, argumentsOfScenario);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 12
 testRunner.When(string.Format("I enter \"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\" in registration page", name, email, confirmEmail, pswd, confirmPswd), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then(string.Format("I should see the \"{0}\" if \"{1}\",\"{2}\" mismatch", emailValidationMessage, email, confirmEmail), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.And(string.Format("I should see \"{0}\" if \"{1}\",\"{2}\" mismatch in registration page", pswdValidationMessage, pswd, confirmPswd), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("create account")]
        [NUnit.Framework.TestCaseAttribute("Test", "tnadiscovery100@gmail.com", "tnadiscovery100@gmail.com", "Test123456", "Test123456", "Verify your email", null)]
        public virtual void CreateAccount(string name, string email, string confirmEmail, string pswd, string confirmPswd, string verifyEmailMsg, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("confirmEmail", confirmEmail);
            argumentsOfScenario.Add("pswd", pswd);
            argumentsOfScenario.Add("confirmPswd", confirmPswd);
            argumentsOfScenario.Add("verifyEmailMsg", verifyEmailMsg);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("create account", null, tagsOfScenario, argumentsOfScenario);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 22
 testRunner.When(string.Format("I enter \"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\" in registration page", name, email, confirmEmail, pswd, confirmPswd), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.Then(string.Format("I should see \"{0}\"", verifyEmailMsg), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("create account, change email, change password, delete account")]
        [NUnit.Framework.TestCaseAttribute("Test", "Verify your email", "tnadiscovery100@gmail.com", "Test123456", "tnatest595@gmail.com", "Test1234", "Test1234", "Your account has been closed and your account data deleted.", null)]
        public virtual void CreateAccountChangeEmailChangePasswordDeleteAccount(string name, string verifyEmailMsg, string oldId, string oldPswd, string newEmail, string newPassword, string confirmNewPassword, string accountDeletionMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("verifyEmailMsg", verifyEmailMsg);
            argumentsOfScenario.Add("oldId", oldId);
            argumentsOfScenario.Add("oldPswd", oldPswd);
            argumentsOfScenario.Add("newEmail", newEmail);
            argumentsOfScenario.Add("newPassword", newPassword);
            argumentsOfScenario.Add("confirmNewPassword", confirmNewPassword);
            argumentsOfScenario.Add("accountDeletionMessage", accountDeletionMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("create account, change email, change password, delete account", null, tagsOfScenario, argumentsOfScenario);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 30
 testRunner.When(string.Format("signin with \"{0}\",\"{1}\", go to your personal details, change email \"{2}\"", oldId, oldPswd, newEmail), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.And(string.Format("signin with \"{0}\", \"{1}\"", newEmail, oldPswd), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.And("for change password go to your personal details, change password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.And(string.Format("for change password enter  \"{0}\",\"{1}\",\"{2}\"", oldPswd, newPassword, confirmNewPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.Then(string.Format("sign in using \"{0}\",\"{1}\"", newEmail, newPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
 testRunner.And(string.Format("delete the account and check for \"{0}\"", accountDeletionMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("forgotten password")]
        [NUnit.Framework.TestCaseAttribute("tnadiscovery100@gmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("testseven@gmail.com", null)]
        public virtual void ForgottenPassword(string email, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("email", email);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("forgotten password", null, tagsOfScenario, argumentsOfScenario);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 42
 testRunner.When(string.Format("click on signin, forgotten your password, enter \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 43
 testRunner.Then("check for the reset your password message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Don\'t accept privacy and cookie policies")]
        [NUnit.Framework.TestCaseAttribute("Test", "tnadiscovery100@gmail.com", "tnadiscovery100@gmail.com", "Discovery1234", "Discovery1234", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "discovery12345@gmail.com", "discovery12345@gmail.com", "Test1234", "Test1234", null)]
        public virtual void DontAcceptPrivacyAndCookiePolicies(string name, string email, string confirmEmail, string pswd, string confirmPswd, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("confirmEmail", confirmEmail);
            argumentsOfScenario.Add("pswd", pswd);
            argumentsOfScenario.Add("confirmPswd", confirmPswd);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Don\'t accept privacy and cookie policies", null, tagsOfScenario, argumentsOfScenario);
#line 50
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 51
 testRunner.When(string.Format("I enter \"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\" but don\'t tick T&C and register", name, email, confirmEmail, pswd, confirmPswd), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 52
 testRunner.Then("check for the validation message You must accept the terms and conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion