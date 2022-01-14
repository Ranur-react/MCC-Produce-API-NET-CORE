var tableEmployee = $('#EmployeeTable').DataTable({

    'ajax': {
        'url': "/Employees/GetAll",
        'dataType': 'json',
        'dataSrc': null,

    },
    dom: 'Bfrtip',
    buttons: [
        {
            extend: 'excelHtml5',
            className: 'btn btn-outline-success rounded-circle ',
            text: '<i class="fas fa-file-excel"></i>',
            title: 'Data Karyawan',
            exportOptions: {
                columns: [2, 1, 3, 4, 5, 6, 7, 8, 9, 10]
            }
        },
        {
            extend: 'pdfHtml5',
            text: '<i class="fas fa-file-pdf"></i>',
            className: 'btn btn-outline-secondary rounded-circle ',
            title: 'Data Karyawan',
            exportOptions: {
                columns: [2, 1, 3, 4, 5, 6, 7, 8, 9, 10]
            }
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i>',
            className: 'btn btn-outline-secondary rounded-circle ',
            title: 'Data Karyawan',
            exportOptions: {
                columns: [2, 1, 3, 4, 5, 6, 7, 8, 9, 10]
            }
        },
    ],

    'columns': [
        {
            'data': null,
            'render': (data, type, row, meta) => {
                return (meta.row + meta.settings._iDisplayStart + 1) + ".";
            }
        },
        {
            'data': null,
            'render': (data, type, row, meta) => {
                return row['firsthName'] + " "+row['lastName']
            }
        },
        {
            'data': 'nik'
        },
        {
            'data': 'phone'
        },
        {
            'data': null,
            'bSortable': false,
            'render': (data, type, row) => {
                return row['gender']==0?'Laki-laki':'Perempuan'
            }

        },
        {
            'data': 'email'
        },
        {
            'data': null,
            'render': (data, type, row) => {
                var dateGet = new Date(row['birthDate']);

                return dateGet.toLocaleDateString();
            }
        },
        {
            'data': null,
            'render': (data, type, row) => formatter.format(row['salary'])
        },
/*        {
            'data': 'gpa'
        },
        {
            'data': 'degree'
        },
        {
            'data': 'universityName'
        },*/
        {
            'data': null,
            'render': (data, type, row) => {
                let dataTerpilih = JSON.stringify(row);
                return `<div class="btn-group" role="group" aria-label="Basic example">
                                                              <button type="button" data-toggle="modal" data-target="#DetailModal " class="btn btn-outline-info DetailButton"><i class="fas fa-info"></i></button>
                                                              <button type="button" data-toggle="modal" data-target="#UpdateModal " class="btn btn-outline-success UpdateButton"><i class="fas fa-edit"></i></button>
                                                              <button type="button" onclick="Remove('${row['nik']}')" class="btn btn-outline-danger rounded-circle "><i class="fas fa-trash"></i></button>
                                                            </div>`
            },
            'bSortable': false
        }

    ],


});
const submit = (type) => {
    if (type == "store") {
        if ($('#truthCheckAdd').is(":checked")) {
            $('#truthHelp').text("");
            storeToApi();
        } else {
            $('.form-tambah').addClass("was-validated");
            $('#truthCheckAdd').focus();
            $('#truthHelp').text("Centang untuk memasstikan Data terimput dengan benar");
        }
    } else {
        var nik=$("#NIKEdit").val();
        //1.Panggil method api update Employees
        console.log("Update on Progress . . ");
        updateToApi();
        var password = $("#PasswordEdit").val();
        if (password != null) {
            //1.Panggil method api update Password
        }
    }

}
const cleanNotif = () => {
    var vN = ['FirstName', 'LastName', 'Phone', 'BirthDate', 'Salary', 'Email', 'Password', 'Degree', 'GPA'];
    for (var i = 0; i < vN.length; i++) {
        $(`#${vN[i]}Help`).text("");
    }
}
const cleanValueAdd = () => {
    var vN = ['NIK', 'FirstName', 'LastName', 'Phone', 'Email', 'Password','truthCheck'];
    for (var i = 0; i < vN.length; i++) {
        $(`#${vN[i]}Add`).val("");
    }
}
const updateToApi = () => {
    var obj = Object();
    obj.nik = $('#NIKEdit').val();
    obj.firsthName = $('#FirstNameEdit').val();
    obj.lastName = $('#LastNameEdit').val();
    obj.phone = $('#PhoneEdit').val();
    obj.birthDate = $('#BirthDateEdit').val();
    obj.salary = parseInt($('#SalaryEdit').val());
    obj.email = $('#EmailEdit').val();
    obj.gender = parseInt($('#GenderEdit').val());
    console.log(obj)
    $.ajax({
        url: "/Employees/Put",
        type: "PUT",
        data: obj

    }).done((result) => {
        console.log(result);
        if (result == 200) {
            $("#UpdateModal").modal('toggle');
            // PopUpSuccess("Success", "Berhasil");
            poUPAlertSweet("success", 'Data berhasil Ubah', "center")
            tableEmployee.ajax.reload();
            cleanNotif();
            cleanValueAdd();
        } else {
            PopUpFailure("Gagal", `Eror: ${JSON.stringify(result)} "Mungkin data salah, periksa kembali data yang diubah"`);
        }

    }).fail((e) => {
        console.log(e.responseJSON);
        PopUpFailure("Gagal", JSON.stringify(e));
    });
}
const storeToApi = () => {
    var obj = Object();
    obj.nik = $('#NIKAdd').val();
    obj.firsthName = $('#FirstNameAdd').val();
    obj.lastName = $('#LastNameAdd').val();
    obj.phone = $('#PhoneAdd').val();
    obj.BirthDate = $('#BirthDateAdd').val();
    obj.salary = parseInt($('#SalaryAdd').val());
    obj.email = $('#EmailAdd').val();
    obj.gender = parseInt($('#GenderAdd').val());
    console.log(obj)
    $.ajax({
        url: "Employees/Post",
        type: "POST",
        data: obj

    }).done((result) => {
        console.log(result);
        if (result == 200) {
            $("#AddModal").modal('toggle');
            // PopUpSuccess("Success", "Berhasil");
            poUPAlertSweet("success", 'Data berhasil Ditambahkan', "center")
            tableEmployee.ajax.reload();
            cleanNotif();
            cleanValueAdd();
        } else {
            PopUpFailure("Gagal", `Eror: ${JSON.stringify(result)} "Mungkin data sudah sudah ada, periksa kembali penginputan"`);
        }
       
    }).fail((e) => {
        console.log(e.responseJSON);
        PopUpFailure("Gagal", JSON.stringify(e));
    });
}
const poUPAlertSweet = (state,title,positions) => {
    Swal.fire({
        position: positions,
        icon: state,
        title: title,
        showConfirmButton: false,
        timer: 2000
    });
}
const PopUpSuccess = (title, content) => {
    $('#popUpModal').modal('show');
    $(".popup-header").html(`<h5 class="modal-title">
    ${title} <i class="fas fa-check-circle text-success"></i>
    </h5>`);
    $(".popup-content").html(`
        ${content}
     `);
    setTimeout(1000, () => {
        $('#popUpModal').modal('hide');
    })
}
const PopUpFailure= (title, content) => {
    $('#popUpModal').modal('show');
    $(".popup-header").html(`<h5 class="modal-title">
    ${title}
<i class="fas fa-times-circle text-danger"></i>
    </h5>`);
    $(".popup-content").html(`
        ${content}
     `);

}


const Edit = (data) => {
    console.log("---- Data Send to Form Edit----------");
    console.log(data);
    ambilDetailDataRegister(data.nik);
    $('#NIKEdit').val(data.nik);
    $('#FirstNameEdit').val(data.firsthName);
    $('#LastNameEdit').val(data.lastName);
    $('#PhoneEdit').val(data.phone);
    $('#EmailEdit').val(data.email);
    $('#BirthDateEdit').val(new Date(data.birthDate +"Z").toISOString().substring(0, 10));
    $('#SalaryEdit').val(data.salary);
   

}
const ambilDetailDataRegister = (nik) => {
    $.ajax({
        url: "/Employees/Get/"+nik,
        type:"GET",
    }).done((result) => {
        if (!result.account) {
            $('#PasswordHelp').text("Akun Login belum Dibuat, Silahkan set Password agar user dapat login sistem");

            $('#DegreeEdit').val("");
            $('#gpaEdit').val("");
        } else {
            $('#PasswordHelp').text("");
            console.log(result.account.profiling)
            if (!result.account.profiling) {
                $('#DegreeEdit').val("");
                $('#gpaEdit').val("");
            } else {
                console.log(result.account.profiling)
                $('#DegreeEdit').val(result.account.profiling.education.degree);
                $('#gpaEdit').val(result.account.profiling.education.gpa);
                $('#UniversityEdit').val(result.account.profiling.education.university.id);
            }
/*            $('#gpaEdit').val(data.gpa);
            $('#UniversityEdit').val(data.university_Id);*/
        }


    })
}
const Remove = (id) => {
    $.ajax({
        url: "Employees/Delete/"+id,
        type: "delete",
        dataType: 'json',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).done((result) => {
        console.log(result);
        //PopUpSuccess("Deleteed Success", "Berhasil mengahpus data " + id);
        poUPAlertSweet("success", 'Berhasil mengahpus data ', "center")
        tableEmployee.ajax.reload();
        cleanNotif();
    }).fail((e) => {
        console.log(e);
    });
}

$(document).ready(function () {
    tableEmployee.ajax.reload();
    $('#BirthDateAdd').val(new Date("1998-02-28T00:00:00Z").toISOString().substring(0, 10));
    $('#EmployeeTable').on('click', '.UpdateButton', function () {
        let rowData = $('#EmployeeTable').DataTable().row($(this).closest('tr')).data();
        Edit(rowData);
    });
    $('#EmployeeTable').on('click', '.DetailButton', function () {
        let rowData = $('#EmployeeTable').DataTable().row($(this).closest('tr')).data();
        Details(rowData);
    });
});
const Details = (data) => {
    var table = "";
    $.each(data, (k, val) => {
        table += `<tr><td class="text-left">${k.toUpperCase()}</td><td class="text-left">: ${val}</td></tr>`;
    });

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-info-outline rounded-circle',
        },
        buttonsStyling: false
    })
    swalWithBootstrapButtons.fire({
        title: `<strong><i class="fas fa-user"></i> ${data.firsthName}</strong>`,
        html:`<div class="table-responsive">
                        <table class="table table-bordered" id="EmployeeTable">
                            <tbody>
                                ${table}
                            </tbody>
                        </table>
                    </div>`,
        showCloseButton: false,
        showCancelButton: false,
        focusConfirm: true,
        confirmButtonText: '<i class="fa fa-times"></i>',
        confirmButtonText: '<i class="fa fa-times"></i>',

    })
}