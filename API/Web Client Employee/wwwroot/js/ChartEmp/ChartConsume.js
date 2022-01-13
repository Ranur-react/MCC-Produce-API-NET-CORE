

$.ajax({
    url: "https://localhost:44321/API/Employees",
    type: "get",
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }

}).done((result) => {
    genDataGenderFilter(result);
    genDataAgeFilter(result);
}).fail((e) => {
    console.log(e);
    PieChartRender([0], ['No Data'], "chartPieGender");
});

const genDataGenderFilter = (result) => {
    var male = result.result.filter((g) => {
        return g.gender == 0;
    });
    var female = result.result.filter((g) => {
        return g.gender == 1;
    });
    PieChartRender([male.length, female.length], ['Laki', 'Perempuan'], "chartPieGender");
}

const genDataAgeFilter = (result) => {
    console.log("BeforeOrder Data");
    console.log(result);
    console.log("Order Data");
    console.log();
    var categories = CollectYear(result);
    var countCategorie=CountYearHaven(result, categories);
    LineChartRender(countCategorie, categories, 'Jumlah', 'chartLineAge');
}

const CollectYear = (data) => {
    var Year = [];
    $.each(orderObjectAscDate(data), (k, val) => {
        var dateTime = new Date(val.birthDate + "Z");
        if (!Year.includes(dateTime.getFullYear())) {
            Year.push(dateTime.getFullYear());
        }
    })
    return Year;
}
const CountYearHaven = (data,Categories) => {
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
    return data.result.sort(function (a, b) {
        return new Date(a.birthDate + "Z") - new Date(b.birthDate + "Z");
    });
}
