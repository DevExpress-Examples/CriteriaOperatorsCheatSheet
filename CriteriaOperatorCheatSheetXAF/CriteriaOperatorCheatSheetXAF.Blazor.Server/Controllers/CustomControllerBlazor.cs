using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Linq;

namespace dxTestSolution.Module.Controllers {
    public class CustomBlazorController : ViewController {
        public CustomBlazorController() {
            var myAction1 = new SimpleAction(this, "MyBlazorAction1", null);
            myAction1.Execute += MyAction1_Execute;
            myAction1.TargetObjectsCriteria = "IsNewObject(This)";
        }

        private void MyAction1_Execute(object sender, SimpleActionExecuteEventArgs e) {
           
        }
    }
}
