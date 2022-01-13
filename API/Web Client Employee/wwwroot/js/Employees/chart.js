

$.ajax({
    url: "/Employees/GetAll",
    type: "get",
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }

}).done((result) => {
    genDataGenderFilter(result);
    genDataSalaryFilter(result);
    genDataAgeFilter(result);
}).fail((e) => {
    console.log(e);
    PieChartRender([0], ['No Data'], "chartPieGender");
});

const genDataGenderFilter = (result) => {
    var male = result.filter((g) => {
        return g.gender == 0;
    });
    var female = result.filter((g) => {
        return g.gender == 1;
    });
    PieChartRender([male.length, female.length], ['Laki', 'Perempuan'], "chartPieGender");
}
const genDataSalaryFilter = (result) => {
/*    var high = result.filter((g) => {
        return g.salary >= 5500000;
    });*/
/*    var low = result.filter((g) => {
        return g.salary < 5500000;
    });*/
    console.log(CollectSalaryCounts(CollectSalaryOrigin(result), result));
    PieChartRender(CollectSalaryCounts(CollectSalaryOrigin(result), result), CollectSalary(result), "chartPieSalary");
}
const CollectSalaryCounts = (data, reference) => {
    var Counts = [];
    $.each(orderObjectAscDate(data), (k, val) => {
        var filter = reference.filter((g) => {
            return g.salary == val;
        });
        console.log("Cek Jumlah yang memiliki gaji");
        console.log(filter);
        console.log(filter.length);
        console.log("End  gaji----");
        Counts.push(filter.length);
    })
    return Counts;
}
const CollectSalary = (data) => {
    var Salary = [];
    $.each(orderObjectAscDate(data), (k, val) => {
        var salRupiah = formatter.format(val.salary.toString());
        if (!Salary.includes(salRupiah)) {
            Salary.push(salRupiah);
        }
    })
    return Salary;
}
const CollectSalaryOrigin = (data) => {
    var Salary = [];
    $.each(orderObjectAscDate(data), (k, val) => {
        var sal = val.salary;
        if (!Salary.includes(sal)) {
            Salary.push(sal);
        }
    })
    return Salary;
}
const genDataAgeFilter = (result) => {
    /*console.log("BeforeOrder Data");
    console.log(result);
    console.log("Order Data");
    console.log();*/
    var categories = CollectYear(result);
    var countCategorie = CountYearHaven(result, categories);
    LineChartRender(countCategorie, categories, 'Jumlah', 'chartLineAge');
    BarChartRender(categories, countCategorie, false, "chartBar");
}

const CollectYear = (data) => {
    var Year = [];
    $.each(orderObjectAscDate(data), (k, val) => {
        var dateTime = new Date(val.birthDate + "Z");
        if (!Year.includes(dateTime.getFullYear().toString())) {
            Year.push(dateTime.getFullYear().toString());
        }
    })
    return Year;
}
const CountYearHaven = (data, Categories) => {
    var Years = [];
    var Count = [];
    $.each(orderObjectAscDate(data), (k, val) => {
        var dateTime = new Date(val.birthDate + "Z");
        Years.push(dateTime.getFullYear());
    })

    $.each(Categories, (k, val) => {
        var CountYearOrder = Years.filter((y) => {
            return y == val;
        });
        Count.push(CountYearOrder.length);
    });
    return Count;
}
const orderObjectAscDate = (data) => {
    return data.sort(function (a, b) {
        return new Date(a.birthDate + "Z") - new Date(b.birthDate + "Z");
    });
}
