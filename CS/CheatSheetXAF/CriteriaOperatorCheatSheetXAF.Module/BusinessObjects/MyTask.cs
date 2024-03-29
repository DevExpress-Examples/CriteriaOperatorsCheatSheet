﻿using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.SystemModule;
using CriteriaOperatorCheatSheetXAF.Module.BusinessObjects;

namespace dxTestSolution.Module.BusinessObjects {
    [DefaultClassOptions]
    [DefaultProperty("Subject")]
    public class MyTask : BaseObject {
        public MyTask(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
        Contact newContact3;
        Department myTaskDepartment;
        Contact newContact1;
        Contact newContact2;
        string _subject;
        public string Subject {
            get {
                return _subject;
            }
            set {
                SetPropertyValue(nameof(Subject), ref _subject, value);
            }
        }
        Contact _assignedTo;
        [Association("Contact-Tasks")]
        [DataSourceCriteria("Owner.Oid==CurrentUserId()")]
        public Contact AssignedTo {
            get { return _assignedTo; }
            set { SetPropertyValue(nameof(AssignedTo), ref _assignedTo, value); }
        }




        [DataSourceCriteria("IsCurrentUserId(Owner.Oid)")]
        public Contact NewContact1 {
            get => newContact1;
            set => SetPropertyValue(nameof(NewContact1), ref newContact1, value);
        }

        [DataSourceCriteria("IsCurrentUserInRole('Default')")]
        public Contact NewContact2 {
            get => newContact2;
            set => SetPropertyValue(nameof(NewContact2), ref newContact2, value);
        }

        [DataSourceCriteria("ContactDepartment = '@This.MyTaskDepartment.Oid'")]
        public Contact NewContact3 {
            get => newContact3;
            set => SetPropertyValue(nameof(NewContact3), ref newContact3, value);
        }
        bool _isActive;
        public bool IsActive {
            get {
                return _isActive;
            }
            set {
                SetPropertyValue(nameof(IsActive), ref _isActive, value);
            }
        }
        Priority _priority;
        public Priority Priority {
            get {
                return _priority;
            }
            set {
                SetPropertyValue(nameof(Priority), ref _priority, value);
            }
        }

        
        public Department MyTaskDepartment {
            get => myTaskDepartment;
            set => SetPropertyValue(nameof(MyTaskDepartment), ref myTaskDepartment, value);
        }
    }
    public enum Priority {
        [ImageName("State_Priority_Low")]
        Low = 0,
        [ImageName("State_Priority_Normal")]
        Normal = 1,
        [ImageName("State_Priority_High")]
        High = 2
    }
}