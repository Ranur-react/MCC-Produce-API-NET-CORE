//chart line 
const LineChartRender = (data, categorie, labelName, elementSelector) => {
    var options = {
        chart: {
            type: 'line',
            toolbar: {
                show: true,
                offsetX: 0,
                offsetY: 0,
                tools: {
                    download: true,
                    selection: true,
                    zoom: true,
                    zoomin: true,
                    zoomout: true,
                    pan: true,
                    reset: true | '<img src="/static/icons/reset.png" width="20">',
                    customIcons: []
                },
                export: {
                    csv: {
                        filename: "Employees Chart CSV",
                        columnDelimiter: ',',
                        headerCategory: 'Kategori',
                        headerValue: 'Value',
                        dateFormatter(timestamp) {
                            return new Date(timestamp).toDateString()
                        }
                    },
                    svg: {
                        filename: "Employees Chart as Icon",
                    },
                    png: {
                        filename: "Employees Chart as Image",
                    }
                },
                autoSelected: 'zoom'
            },
        },
        series: [{
            name: labelName ,
            data: data
        }],
        xaxis: {
            categories: categorie
        }
    }

    var chart = new ApexCharts(document.querySelector(`#${elementSelector}`), options);
    chart.render();
}


var PieChartRender = (data,labels, elementSelector) => {
    //chart Pie 
    var PieOptions = {
        chart: {
            type: 'donut',
            toolbar: {
                show: true,
                offsetX: 0,
                offsetY: 0,
                tools: {
                    download: true,
                    selection: true,
                    zoom: true,
                    zoomin: true,
                    zoomout: true,
                    pan: true,
                    reset: true | '<img src="/static/icons/reset.png" width="20">',
                    customIcons: []
                },
                export: {
                    csv: {
                        filename: "Employees Chart CSV",
                        columnDelimiter: ',',
                        headerCategory: 'Kategori',
                        headerValue: 'Value',
                        dateFormatter(timestamp) {
                            return new Date(timestamp).toDateString()
                        }
                    },
                    svg: {
                        filename: "Employees Chart as Icon",
                    },
                    png: {
                        filename: "Employees Chart as Image",
                    }
                },
                autoSelected: 'zoom'
            },
        },
        export: {
            csv: {
                filename: "CSV ChartFiles",
                columnDelimiter: ',',
                headerCategory: 'Category',
                headerValue: 'Value',
                dateFormatter(timestamp) {
                    return new Date(timestamp).toDateString()
                }
            },
            svg: {
                filename: "SVG of ChartFiles",
            },
            png: {
                filename: "PNG of ChartFiles",
            }
        },
        series: data,
        labels: labels,
    }
    var chartPie = new ApexCharts(document.querySelector(`#${elementSelector}`), PieOptions);
    chartPie.render();
}

const BarChartRender = (dataX, DataY,rotations,elementSelector,) => {
    var dataDisplay = [];
    console.log("Cek data bar");
    $.each(dataX,(k, val)=> {
        dataDisplay.push({ x: val, y: DataY[k] })
    });
console.log(dataDisplay);
    var options = {
        chart: {
            type: 'bar',
            toolbar: {
                show: true,
                offsetX: 0,
                offsetY: 0,
                tools: {
                    download: true,
                    selection: true,
                    zoom: true,
                    zoomin: true,
                    zoomout: true,
                    pan: true,
                    reset: true | '<img src="/static/icons/reset.png" width="20">',
                    customIcons: []
                },
                export: {
                    csv: {
                        filename: "Employees Chart CSV",
                        columnDelimiter: ',',
                        headerCategory: 'Kategori',
                        headerValue: 'Value',
                        dateFormatter(timestamp) {
                            return new Date(timestamp).toDateString()
                        }
                    },
                    svg: {
                        filename: "Employees Chart as Icon",
                    },
                    png: {
                        filename: "Employees Chart as Image",
                    }
                },
                autoSelected: 'zoom'
            },
        },
        export: {
            csv: {
                filename: "CSV ChartFiles",
                columnDelimiter: ',',
                headerCategory: 'Category',
                headerValue: 'Value',
                dateFormatter(timestamp) {
                    return new Date(timestamp).toDateString()
                }
            },
            svg: {
                filename: "SVG of ChartFiles",
            },
            png: {
                filename: "PNG of ChartFiles",
            }
        },
        plotOptions: {
            bar: {
                horizontal: rotations,
            }
        },
        series: [{
            data: dataDisplay
        }]
    }

    var chart = new ApexCharts(document.querySelector(`#${elementSelector}`), options);
    chart.render();
}
