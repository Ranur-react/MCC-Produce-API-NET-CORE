$(document).ready(function () {
    $('#BirthDateAdd').val(new Date("1998-02-28T00:00:00Z").toISOString().substring(0, 10));
});
const storeToApi = (src) => {
    console.log("Source: ");
    if ($('#truthCheckAdd').is(":checked")) {
        $('#truthHelp').text("");
        var obj = Object();
        obj.firstName = $('#FirstNameAdd').val();
        obj.LastName = $('#LastNameAdd').val();
        obj.Phone = $('#PhoneAdd').val();
        obj.BirthDate = $('#BirthDateAdd').val();
        obj.Salary = parseInt($('#SalaryAdd').val());
        obj.Email = $('#EmailAdd').val();
        obj.Gender = parseInt($('#GenderAdd').val());
        obj.Password = $('#PasswordAdd').val();
        obj.Degree = $('#DegreeAdd').val();
        obj.GPA = parseFloat($('#gpaAdd').val());
        obj.University_Id = parseFloat($('#UniversityAdd').val());
        console.log(obj)
        $.ajax({
            //url: "https://localhost:44321/API/Employees/Register",
            url: "/Accounts/RegisterNew",
            type: "post",
            dataType:"json",
            data: obj

        }).done((result) => {
          
            console.log(result.status);

            if (result.status == 201) {
             
                 console.log(src);
                 if (src == 'admin') {
                     poUPAlertSweet("success", "success", 'Data berhasil Ditambahkan', "center").then(function () {
                         window.location = "/Employees";
                     });
                 } else {
                     poUPAlertSweet("success", "success", 'Data berhasil Ditambahkan', "center").then(function () {
                         window.location = "/Logins";
                     });
                 }
                 cleanNotif();
                 cleanValueAdd();
            } else {
                if (result.status == 406) {
                    cleanNotif();
                    if (result.result == 2) {
                        $("#EmailHelp").text(result.message);
                    } else if (result.result == 3) {
                        $("#PhoneHelp").text(result.message);
                    }
                } else if (result.status == 400) {
                    cleanNotif();
                    console.log("yang eror itu");
                    var yr = Object.keys(result.errors);
                    for (var i = 0; i < yr.length; i++) {
                        console.log(result.errors[yr[i]][0]);
                        $(`#${yr[i]}Help`).text("the " + yr[i] + " " + result.errors[yr[i]][0]);
                        $(`#${yr[i]}Add`).focus();
                    }

                } else {
                    poUPAlertSweet("error", "Gagal", JSON.stringify(result.errors), "center")
                }
            }
           
        }).fail((e) => {
            console.log(e);
         
        });
    } else {
        $('.form-tambah').addClass("was-validated");
        $('#truthCheckAdd').focus();
        $('#truthHelp').text("Centang untuk memasstikan Data terimput dengan benar");
    }
   
}
const poUPAlertSweet = (state, title, texts, positions) => {
   return Swal.fire({
        position: positions,
        icon: state,
        title: title,
        text: texts,
        showConfirmButton: false,
        timer: 2000
    });
}
const cleanNotif = () => {
    var vN = ['FirstName', 'LastName', 'Phone', 'BirthDate', 'Salary', 'Email', 'Password', 'Degree', 'GPA'];
    for (var i = 0; i < vN.length; i++) {
        $(`#${vN[i]}Help`).text("");
    }
}
const cleanValueAdd = () => {
    var vN = ['FirstName', 'LastName', 'Phone', 'Email', 'Password'];
    for (var i = 0; i < vN.length; i++) {
        $(`#${vN[i]}Add`).val("");
    }
}