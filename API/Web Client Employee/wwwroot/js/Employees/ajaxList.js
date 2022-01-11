var tableEmployee = $('#EmployeeTable').DataTable({

    'ajax': {
        'url': "https://localhost:44321/api/Employees/RegisteredData",
        'dataType': 'json',
        'dataSrc': 'result',
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
            'data': 'fullName'
        },
        {
            'data': 'nik'
        },
        {
            'data': 'phoneNumber'
        },
        {
            'data': 'gender',
            'bSortable': false

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
        {
            'data': 'gpa'
        },
        {
            'data': 'degree'
        },
        {
            'data': 'universityName'
        },
        {
            'data': null,
            'render': (data, type, row) => {
                return `<div class="btn-group" role="group" aria-label="Basic example">
                                                              <button type="button" onclick="Edit(${data})" data-toggle="modal" data-target="#UpdateModal " class="btn btn-outline-success rounded-circle m-1"><i class="fas fa-edit"></i></button>
                                                              <button type="button" onclick="Remove('${row['nik']}')" class="btn btn-outline-danger rounded-circle m-1"><i class="fas fa-trash"></i></button>
                                                            </div>`
            },
            'bSortable': false
        }

    ],


});
var formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'IDR'
});

const submit = () => {
    if ($('#truthCheck').is(":checked")) {
        $('#truthHelp').text("");
        storeToApi();
    } else {
        $('#truthCheck').focus();
        $('#truthHelp').text("Centang untuk memasstikan Data terimput dengan benar");
    }
}
const cleanNotif = () => {
    var vN = ['FirstName', 'LastName', 'Phone', 'BirthDate', 'Salary', 'Email', 'Password', 'Degree', 'GPA'];
    for (var i = 0; i < vN.length; i++) {
        $(`#${vN[i]}Help`).text("");
    }
}
const cleanValueAdd = () => {
    var vN = ['FirstName', 'LastName', 'Phone','Email', 'Password'];
    for (var i = 0; i < vN.length; i++) {
        $(`#${vN[i]}Add`).val("");
    }
}
const storeToApi = () => {
    var obj = Object();
    obj.FirstName = $('#FirstNameAdd').val();
    obj.LastName = $('#LastNameAdd').val();
    obj.Phone = $('#PhoneAdd').val();
    obj.BirthDate = $('#BirthDateAdd').val();
    obj.Salary = parseInt($('#SalaryAdd').val());
    obj.Email = $('#EmailAdd').val();
    obj.Gender = parseInt($('#GenderAdd').val());
    obj.Password = $('#PasswordAdd').val();
    obj.Degree = $('#DegreeAdd').val();
    obj.GPA = parseInt($('#gpaAdd').val());
    obj.University_Id = parseInt($('#UniversityAdd').val());
    console.log(obj)
    $.ajax({
        url: "https://localhost:44321/API/Employees/Register",
        type: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        dataType: 'json',
        data: JSON.stringify(obj)

    }).done((result) => {
        console.log(result);
        $("#AddModal").modal('toggle');
       // PopUpSuccess("Success", "Berhasil");
        poUPAlertSweet("success", 'Data berhasil Ditambahkan', "center")
        tableEmployee.ajax.reload();
        cleanNotif();
        cleanValueAdd();
    }).fail((e) => {
        console.log(e.responseJSON);
        if (e.responseJSON.status == 406) {
            cleanNotif();
            if (e.responseJSON.result == 2) {
                $("#EmailHelp").text(e.responseJSON.message);
            } else if (e.responseJSON.result == 3) {
                $("#PhoneHelp").text(e.responseJSON.message);
            }
        } else if (e.responseJSON.status == 400) {
            cleanNotif();
            console.log("yang eror itu");
            var yr = Object.keys(e.responseJSON.errors);
            for (var i = 0; i < yr.length; i++) {
                console.log(e.responseJSON.errors[yr[i]][0]);
                $(`#${yr[i]}Help`).text("the"+ yr[i]+" "+e.responseJSON.errors[yr[i]][0]);
            }
               
        } else {
            PopUpFailure("Gagal", JSON.stringify(e.responseJSON.errors));
        }
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

$(document).ready(function () {
    
    tableEmployee.ajax.reload();
});
const Edit = (data) => {
    console.log(data);
}
const Remove = (id) => {
    $.ajax({
        url: "https://localhost:44321/API/Employees/"+id,
        type: "delete",
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