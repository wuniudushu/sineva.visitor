using System;
using System.Collections.Generic;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VisitorSystem.VisitorsSystem.OASystem;

namespace VisitorSystem.EntityFrameworkCore
{
    public partial class OALLPContext : DbContext
    {
        public OALLPContext()
        {
        }

        public OALLPContext(DbContextOptions<OALLPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HrmResource> HrmResources { get; set; }
        public virtual DbSet<Oatest> Oatests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=OALLP;uid=sa;pwd=20121225llp;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrmResource>(entity =>
            {
                entity.ToTable("HrmResource");

                entity.HasIndex(e => new { e.Departmentid, e.Lastname }, "IX_HRMRESCE_TD");

                entity.HasIndex(e => new { e.Loginid, e.Account }, "IX_HRMRESOURCE_LA");

                entity.HasIndex(e => new { e.Subcompanyid1, e.Status }, "IX_HRMRESOURCE_SIDST");

                entity.HasIndex(e => new { e.Status, e.Id, e.Dsporder }, "IX_HRMRSC_CNN");

                entity.HasIndex(e => new { e.Loginid, e.Id }, "IX_HRMRSC_LID");

                entity.HasIndex(e => new { e.Status, e.Lastname, e.Pinyinlastname, e.Loginid }, "IX_HRMRSC_LP");

                entity.HasIndex(e => new { e.Loginid, e.Status }, "IX_HRMRSUC_STTS");

                entity.HasIndex(e => e.Departmentid, "IX_HrmResource_dept");

                entity.HasIndex(e => e.Managerid, "IX_HrmResource_manager");

                entity.HasIndex(e => e.Id, "_dta_index_HrmResource_8_130099504__K1");

                entity.HasIndex(e => e.Islabouunion, "_dta_index_HrmResource_8_130099504__K111");

                entity.HasIndex(e => new { e.Islabouunion, e.Id }, "_dta_index_HrmResource_8_130099504__K111_K1");

                entity.HasIndex(e => new { e.Id, e.Departmentid, e.Subcompanyid1 }, "_dta_index_HrmResource_8_130099504__K1_K36_K37_5");

                entity.HasIndex(e => new { e.Departmentid, e.Subcompanyid1, e.Id }, "_dta_index_HrmResource_8_130099504__K36_K37_K1_5");

                entity.HasIndex(e => new { e.Islabouunion, e.Id }, "_dta_stat_130099504_111_1");

                entity.HasIndex(e => new { e.Departmentid, e.Subcompanyid1, e.Id }, "_dta_stat_130099504_36_37_1");

                entity.HasIndex(e => new { e.Id, e.Departmentid }, "hrmresource_id");

                entity.HasIndex(e => e.Outkey, "idx_hrmresource_cd");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("account");

                entity.Property(e => e.Accountid1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("accountid1");

                entity.Property(e => e.Accountname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("accountname");

                entity.Property(e => e.Accounttype).HasColumnName("accounttype");

                entity.Property(e => e.Accumfundaccount)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("accumfundaccount");

                entity.Property(e => e.Adbm)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("adbm");

                entity.Property(e => e.Adgs)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("adgs");

                entity.Property(e => e.Adsjgs)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("adsjgs");

                entity.Property(e => e.Assistantdactylogram)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("assistantdactylogram");

                entity.Property(e => e.Assistantid).HasColumnName("assistantid");

                entity.Property(e => e.Bankid1).HasColumnName("bankid1");

                entity.Property(e => e.Beforefrozen).HasColumnName("beforefrozen");

                entity.Property(e => e.Belongto).HasColumnName("belongto");

                entity.Property(e => e.Bememberdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bememberdate")
                    .IsFixedLength();

                entity.Property(e => e.Bepartydate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bepartydate")
                    .IsFixedLength();

                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birthday")
                    .IsFixedLength();

                entity.Property(e => e.Birthplace)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("birthplace");

                entity.Property(e => e.Certificatenum)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("certificatenum");

                entity.Property(e => e.Classification)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("classification")
                    .HasDefaultValueSql("((3))")
                    .IsFixedLength();

                entity.Property(e => e.Companystartdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("companystartdate");

                entity.Property(e => e.Companyworkyear)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("companyworkyear");

                entity.Property(e => e.Costcenterid).HasColumnName("costcenterid");

                entity.Property(e => e.Countryid)
                    .HasColumnName("countryid")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.Createdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("createdate")
                    .IsFixedLength();

                entity.Property(e => e.Creater).HasColumnName("creater");

                entity.Property(e => e.Createrid).HasColumnName("createrid");

                entity.Property(e => e.Dactylogram)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("dactylogram");

                entity.Property(e => e.Datefield1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("datefield1");

                entity.Property(e => e.Datefield2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("datefield2");

                entity.Property(e => e.Datefield3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("datefield3");

                entity.Property(e => e.Datefield4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("datefield4");

                entity.Property(e => e.Datefield5)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("datefield5");

                entity.Property(e => e.Degree)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("degree");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Dismissdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISMISSDATE");

                entity.Property(e => e.Dsporder).HasColumnName("dsporder");

                entity.Property(e => e.EcologyPinyinSearch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ecology_pinyin_search");

                entity.Property(e => e.Educationlevel).HasColumnName("educationlevel");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enddate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("enddate")
                    .IsFixedLength();

                entity.Property(e => e.Extphone)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("extphone");

                entity.Property(e => e.Fax)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("fax");

                entity.Property(e => e.Folk)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("folk");

                entity.Property(e => e.Haschangepwd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("haschangepwd");

                entity.Property(e => e.Healthinfo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("healthinfo")
                    .IsFixedLength();

                entity.Property(e => e.Height)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("height");

                entity.Property(e => e.Homeaddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("homeaddress");

                entity.Property(e => e.IsAdaccount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("isADAccount")
                    .IsFixedLength();

                entity.Property(e => e.Islabouunion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("islabouunion")
                    .IsFixedLength();

                entity.Property(e => e.Isnewuser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("isnewuser");

                entity.Property(e => e.Jobactivitydesc)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("jobactivitydesc");

                entity.Property(e => e.Jobcall).HasColumnName("jobcall");

                entity.Property(e => e.Joblevel).HasColumnName("joblevel");

                entity.Property(e => e.Jobtitle).HasColumnName("jobtitle");

                entity.Property(e => e.Lastlogindate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("lastlogindate")
                    .IsFixedLength();

                entity.Property(e => e.Lastmoddate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("lastmoddate")
                    .IsFixedLength();

                entity.Property(e => e.Lastmodid).HasColumnName("lastmodid");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Lloginid)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("lloginid");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Loginid)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("loginid");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Managerstr)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("managerstr");

                entity.Property(e => e.Maritalstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("maritalstatus")
                    .IsFixedLength();

                entity.Property(e => e.Messagerurl)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("messagerurl");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Mobilecaflag)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobilecaflag");

                entity.Property(e => e.Mobilecall)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("mobilecall");

                entity.Property(e => e.Mobileshowtype).HasColumnName("mobileshowtype");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.Modifier).HasColumnName("modifier");

                entity.Property(e => e.MsgStyle)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("msgStyle");

                entity.Property(e => e.Nationality).HasColumnName("nationality");

                entity.Property(e => e.Nativeplace)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("nativeplace");

                entity.Property(e => e.Needdynapass).HasColumnName("needdynapass");

                entity.Property(e => e.Needusb).HasColumnName("needusb");

                entity.Property(e => e.Notallot).HasColumnName("notallot");

                entity.Property(e => e.Numberfield1).HasColumnName("numberfield1");

                entity.Property(e => e.Numberfield2).HasColumnName("numberfield2");

                entity.Property(e => e.Numberfield3).HasColumnName("numberfield3");

                entity.Property(e => e.Numberfield4).HasColumnName("numberfield4");

                entity.Property(e => e.Numberfield5).HasColumnName("numberfield5");

                entity.Property(e => e.OccupySpace)
                    .HasColumnName("occupySpace")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Oldpassword1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("oldpassword1");

                entity.Property(e => e.Oldpassword2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("oldpassword2");

                entity.Property(e => e.Outkey)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("outkey");

                entity.Property(e => e.Passwdchgdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("passwdchgdate")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordLockReason)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("passwordLockReason");

                entity.Property(e => e.Passwordlock).HasColumnName("passwordlock");

                entity.Property(e => e.Passwordlocktime)
                    .HasColumnType("datetime")
                    .HasColumnName("passwordlocktime");

                entity.Property(e => e.Passwordstate).HasColumnName("passwordstate");

                entity.Property(e => e.Pinyinlastname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("pinyinlastname");

                entity.Property(e => e.Policy)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("policy");

                entity.Property(e => e.Probationenddate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("probationenddate")
                    .IsFixedLength();

                entity.Property(e => e.Regresidentplace)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("regresidentplace");

                entity.Property(e => e.Residentphone)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("residentphone");

                entity.Property(e => e.Residentplace)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("residentplace");

                entity.Property(e => e.Residentpostcode)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("residentpostcode");

                entity.Property(e => e.Resourcefrom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("resourcefrom");

                entity.Property(e => e.Resourceimageid).HasColumnName("resourceimageid");

                entity.Property(e => e.Resourcetype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("resourcetype")
                    .IsFixedLength();

                entity.Property(e => e.Salt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("salt");

                entity.Property(e => e.Seclevel).HasColumnName("seclevel");

                entity.Property(e => e.SecondaryPwd)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("secondaryPwd");

                entity.Property(e => e.Serial)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("serial");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sex")
                    .IsFixedLength();

                entity.Property(e => e.Startdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("startdate")
                    .IsFixedLength();

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subcompanyid1).HasColumnName("subcompanyid1");

                entity.Property(e => e.Sumpasswordwrong).HasColumnName("sumpasswordwrong");

                entity.Property(e => e.Systemlanguage).HasColumnName("systemlanguage");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("telephone");

                entity.Property(e => e.Tempresidentnumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("tempresidentnumber");

                entity.Property(e => e.Textfield1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("textfield1");

                entity.Property(e => e.Textfield2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("textfield2");

                entity.Property(e => e.Textfield3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("textfield3");

                entity.Property(e => e.Textfield4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("textfield4");

                entity.Property(e => e.Textfield5)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("textfield5");

                entity.Property(e => e.Tinyintfield1).HasColumnName("tinyintfield1");

                entity.Property(e => e.Tinyintfield2).HasColumnName("tinyintfield2");

                entity.Property(e => e.Tinyintfield3).HasColumnName("tinyintfield3");

                entity.Property(e => e.Tinyintfield4).HasColumnName("tinyintfield4");

                entity.Property(e => e.Tinyintfield5).HasColumnName("tinyintfield5");

                entity.Property(e => e.Tokenkey)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("tokenkey");

                entity.Property(e => e.TotalSpace)
                    .HasColumnName("totalSpace")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Usbstate).HasColumnName("usbstate");

                entity.Property(e => e.UseSecondaryPwd).HasColumnName("useSecondaryPwd");

                entity.Property(e => e.Usekind).HasColumnName("usekind");

                entity.Property(e => e.UserUsbType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("userUsbType");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("uuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Workcode)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("workcode");

                entity.Property(e => e.Workroom)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("workroom");

                entity.Property(e => e.Workstartdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("workstartdate");

                entity.Property(e => e.Workyear)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("workyear");
            });

            modelBuilder.Entity<Oatest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OATest");

                entity.Property(e => e.CreationTime)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TestName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VisitorCompany)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VisitorIdcard)
                    .HasMaxLength(10)
                    .HasColumnName("VisitorIDCard")
                    .IsFixedLength();

                entity.Property(e => e.VisitorName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VisitorPhoneNum)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
