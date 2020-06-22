

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace Entity {

    [Table("EmployeeMaster")]
    public class EmployeeMaster {
        [Key]
        public int ID { get; set; }

       
        public string EmpName { get; set; }

    
        public double Salary { get; set; }

   
        public string Designation { get; set; }
    }

}
