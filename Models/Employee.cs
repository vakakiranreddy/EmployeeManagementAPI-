namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; } // primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
