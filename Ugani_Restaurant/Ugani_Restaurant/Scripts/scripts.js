$(document).ready(function () {
    $("#btnaddCard").click(function () {
        $.ajax({
            type: "POST",
            url: "/MONANs/AddToCard",
            data: {
                makh: '96a25676-b8c2-4682-9952-12022f8719e8',
                mamonan: 1,
                soluong: 1,
                ngaydat: date
    },
        success: function (result) {
            // Xử lý kết quả trả về khi hàm được gọi thành công
        },
        error: function (xhr, status, error) {
            // Xử lý lỗi nếu có
        }
                                    });
                                });
                            });