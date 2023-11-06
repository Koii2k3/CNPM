using DALL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Presentation Layer(GUI): Lớp này có nhiệm vụ giao tiếp với người dùng, hiển thị các thành phần giao diện như win form,
    web form, và thực hiện các công việc như nhập liệu, hiển thị dữ liệu, kiểm tra tính đúng đắn của dữ liệu trước khi
    gọi lớp Business Logic Layer (BLL).
Business Logic Layer (BLL): Lớp này xử lý các yêu cầu thao tác dữ liệu từ Presentation Layer, xử lý chính nguồn dữ liệu
    từ Presentation Layer trước khi truyền xuống Data Access Layer và lưu xuống hệ quản trị CSDL. Ngoài ra, BLL còn kiểm
    tra các ràng buộc, tính toàn vẹn và hợp lệ của dữ liệu, thực hiện tính toán và xử lý các yêu cầu nghiệp vụ trước khi
    trả kết quả về Presentation Layer.
Data Access Layer (DAL): Lớp này giao tiếp với hệ quản trị CSDL như thực hiện các công việc liên quan đến lưu trữ và
    truy vấn dữ liệu.*/

namespace BLLL
{
    public class TypeBLL
    {
        TypeAccessDAL type_access = new TypeAccessDAL();
        public string[] getUserType()
        {
            return type_access.getUserType();
        }
    }
}
