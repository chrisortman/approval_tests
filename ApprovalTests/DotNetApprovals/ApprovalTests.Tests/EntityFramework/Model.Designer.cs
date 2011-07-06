﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("Model", "FK_Employee_Company", "Company", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(ApprovalTests.Tests.EntityFramework.Company), "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ApprovalTests.Tests.EntityFramework.Employee), true)]
[assembly: EdmRelationshipAttribute("Model", "FK_Boss", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(ApprovalTests.Tests.EntityFramework.Employee), "Employee1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ApprovalTests.Tests.EntityFramework.Employee), true)]
[assembly: EdmRelationshipAttribute("Model", "FK_Events_Employee", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(ApprovalTests.Tests.EntityFramework.Employee), "Event", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ApprovalTests.Tests.EntityFramework.Event), true)]
[assembly: EdmRelationshipAttribute("Model", "FK_Job_Employee", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ApprovalTests.Tests.EntityFramework.Employee), "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ApprovalTests.Tests.EntityFramework.Job), true)]

#endregion

namespace ApprovalTests.Tests.EntityFramework
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ModelContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ModelContainer object using the connection string found in the 'ModelContainer' section of the application configuration file.
        /// </summary>
        public ModelContainer() : base("name=ModelContainer", "ModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ModelContainer object.
        /// </summary>
        public ModelContainer(string connectionString) : base(connectionString, "ModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ModelContainer object.
        /// </summary>
        public ModelContainer(EntityConnection connection) : base(connection, "ModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Company> Companies
        {
            get
            {
                if ((_Companies == null))
                {
                    _Companies = base.CreateObjectSet<Company>("Companies");
                }
                return _Companies;
            }
        }
        private ObjectSet<Company> _Companies;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Employee> Employees
        {
            get
            {
                if ((_Employees == null))
                {
                    _Employees = base.CreateObjectSet<Employee>("Employees");
                }
                return _Employees;
            }
        }
        private ObjectSet<Employee> _Employees;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Event> Events
        {
            get
            {
                if ((_Events == null))
                {
                    _Events = base.CreateObjectSet<Event>("Events");
                }
                return _Events;
            }
        }
        private ObjectSet<Event> _Events;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Job> Jobs
        {
            get
            {
                if ((_Jobs == null))
                {
                    _Jobs = base.CreateObjectSet<Job>("Jobs");
                }
                return _Jobs;
            }
        }
        private ObjectSet<Job> _Jobs;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<sysdiagram> sysdiagrams
        {
            get
            {
                if ((_sysdiagrams == null))
                {
                    _sysdiagrams = base.CreateObjectSet<sysdiagram>("sysdiagrams");
                }
                return _sysdiagrams;
            }
        }
        private ObjectSet<sysdiagram> _sysdiagrams;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Companies EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCompanies(Company company)
        {
            base.AddObject("Companies", company);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Events EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEvents(Event @event)
        {
            base.AddObject("Events", @event);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Jobs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToJobs(Job job)
        {
            base.AddObject("Jobs", job);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the sysdiagrams EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTosysdiagrams(sysdiagram sysdiagram)
        {
            base.AddObject("sysdiagrams", sysdiagram);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Company")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Company : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Company object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static Company CreateCompany(global::System.Int32 id)
        {
            Company company = new Company();
            company.Id = id;
            return company;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Website
        {
            get
            {
                return _Website;
            }
            set
            {
                OnWebsiteChanging(value);
                ReportPropertyChanging("Website");
                _Website = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Website");
                OnWebsiteChanged();
            }
        }
        private global::System.String _Website;
        partial void OnWebsiteChanging(global::System.String value);
        partial void OnWebsiteChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Employee_Company", "Employee")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("Model.FK_Employee_Company", "Employee");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("Model.FK_Employee_Company", "Employee", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Employee")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Employee : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static Employee CreateEmployee(global::System.Int32 id)
        {
            Employee employee = new Employee();
            employee.Id = id;
            return employee;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Boss
        {
            get
            {
                return _Boss;
            }
            set
            {
                OnBossChanging(value);
                ReportPropertyChanging("Boss");
                _Boss = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Boss");
                OnBossChanged();
            }
        }
        private Nullable<global::System.Int32> _Boss;
        partial void OnBossChanging(Nullable<global::System.Int32> value);
        partial void OnBossChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Company
        {
            get
            {
                return _Company;
            }
            set
            {
                OnCompanyChanging(value);
                ReportPropertyChanging("Company");
                _Company = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Company");
                OnCompanyChanged();
            }
        }
        private Nullable<global::System.Int32> _Company;
        partial void OnCompanyChanging(Nullable<global::System.Int32> value);
        partial void OnCompanyChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Employee_Company", "Company")]
        public Company Company1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Company>("Model.FK_Employee_Company", "Company").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Company>("Model.FK_Employee_Company", "Company").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Company> Company1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Company>("Model.FK_Employee_Company", "Company");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Company>("Model.FK_Employee_Company", "Company", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Boss", "Employee1")]
        public EntityCollection<Employee> Employee1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("Model.FK_Boss", "Employee1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("Model.FK_Boss", "Employee1", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Boss", "Employee")]
        public Employee Employee2
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Boss", "Employee").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Boss", "Employee").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> Employee2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Boss", "Employee");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("Model.FK_Boss", "Employee", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Events_Employee", "Event")]
        public EntityCollection<Event> Events
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Event>("Model.FK_Events_Employee", "Event");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Event>("Model.FK_Events_Employee", "Event", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Job_Employee", "Job")]
        public EntityCollection<Job> Jobs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Job>("Model.FK_Job_Employee", "Job");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Job>("Model.FK_Job_Employee", "Job", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Event")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Event : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Event object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static Event CreateEvent(global::System.Int32 id)
        {
            Event @event = new Event();
            @event.Id = id;
            return @event;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                OnEmployeeChanging(value);
                ReportPropertyChanging("Employee");
                _Employee = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Employee");
                OnEmployeeChanged();
            }
        }
        private Nullable<global::System.Int32> _Employee;
        partial void OnEmployeeChanging(Nullable<global::System.Int32> value);
        partial void OnEmployeeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EventTitle
        {
            get
            {
                return _EventTitle;
            }
            set
            {
                OnEventTitleChanging(value);
                ReportPropertyChanging("EventTitle");
                _EventTitle = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EventTitle");
                OnEventTitleChanged();
            }
        }
        private global::System.String _EventTitle;
        partial void OnEventTitleChanging(global::System.String value);
        partial void OnEventTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Details
        {
            get
            {
                return _Details;
            }
            set
            {
                OnDetailsChanging(value);
                ReportPropertyChanging("Details");
                _Details = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Details");
                OnDetailsChanged();
            }
        }
        private global::System.String _Details;
        partial void OnDetailsChanging(global::System.String value);
        partial void OnDetailsChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Events_Employee", "Employee")]
        public Employee Employee1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Events_Employee", "Employee").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Events_Employee", "Employee").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> Employee1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Events_Employee", "Employee");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("Model.FK_Events_Employee", "Employee", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="Job")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Job : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Job object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="employee">Initial value of the Employee property.</param>
        public static Job CreateJob(global::System.Int32 id, global::System.Int32 employee)
        {
            Job job = new Job();
            job.Id = id;
            job.Employee = employee;
            return job;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                OnEmployeeChanging(value);
                ReportPropertyChanging("Employee");
                _Employee = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Employee");
                OnEmployeeChanged();
            }
        }
        private global::System.Int32 _Employee;
        partial void OnEmployeeChanging(global::System.Int32 value);
        partial void OnEmployeeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                OnStatusChanging(value);
                ReportPropertyChanging("Status");
                _Status = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Status");
                OnStatusChanged();
            }
        }
        private global::System.String _Status;
        partial void OnStatusChanging(global::System.String value);
        partial void OnStatusChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model", "FK_Job_Employee", "Employee")]
        public Employee Employee1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Job_Employee", "Employee").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Job_Employee", "Employee").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> Employee1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("Model.FK_Job_Employee", "Employee");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("Model.FK_Job_Employee", "Employee", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model", Name="sysdiagram")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class sysdiagram : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new sysdiagram object.
        /// </summary>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="principal_id">Initial value of the principal_id property.</param>
        /// <param name="diagram_id">Initial value of the diagram_id property.</param>
        public static sysdiagram Createsysdiagram(global::System.String name, global::System.Int32 principal_id, global::System.Int32 diagram_id)
        {
            sysdiagram sysdiagram = new sysdiagram();
            sysdiagram.name = name;
            sysdiagram.principal_id = principal_id;
            sysdiagram.diagram_id = diagram_id;
            return sysdiagram;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 principal_id
        {
            get
            {
                return _principal_id;
            }
            set
            {
                Onprincipal_idChanging(value);
                ReportPropertyChanging("principal_id");
                _principal_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("principal_id");
                Onprincipal_idChanged();
            }
        }
        private global::System.Int32 _principal_id;
        partial void Onprincipal_idChanging(global::System.Int32 value);
        partial void Onprincipal_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 diagram_id
        {
            get
            {
                return _diagram_id;
            }
            set
            {
                if (_diagram_id != value)
                {
                    Ondiagram_idChanging(value);
                    ReportPropertyChanging("diagram_id");
                    _diagram_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("diagram_id");
                    Ondiagram_idChanged();
                }
            }
        }
        private global::System.Int32 _diagram_id;
        partial void Ondiagram_idChanging(global::System.Int32 value);
        partial void Ondiagram_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> version
        {
            get
            {
                return _version;
            }
            set
            {
                OnversionChanging(value);
                ReportPropertyChanging("version");
                _version = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("version");
                OnversionChanged();
            }
        }
        private Nullable<global::System.Int32> _version;
        partial void OnversionChanging(Nullable<global::System.Int32> value);
        partial void OnversionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] definition
        {
            get
            {
                return StructuralObject.GetValidValue(_definition);
            }
            set
            {
                OndefinitionChanging(value);
                ReportPropertyChanging("definition");
                _definition = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("definition");
                OndefinitionChanged();
            }
        }
        private global::System.Byte[] _definition;
        partial void OndefinitionChanging(global::System.Byte[] value);
        partial void OndefinitionChanged();

        #endregion
    
    }

    #endregion
    
}
