//chart line 
var options = {
    chart: {
        type: 'line'
    },
    series: [{
        name: 'sales',
        data: [30, 40, 35, 50, 49, 60, 70, 91, 125]
    }],
    xaxis: {
        categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999]
    }
}

var chart = new ApexCharts(document.querySelector("#chartLine"), options);

chart.render();


//chart Pie 
var PieOptions = {
    chart: {
        type: 'donut'
    },
    series: [10, 10, 10, 70],
    labels: ['Apple', 'Mango', 'Orange', 'Watermelon'],

  
}

var chartPie = new ApexCharts(document.querySelector("#chartPie"), PieOptions );

chartPie.render();