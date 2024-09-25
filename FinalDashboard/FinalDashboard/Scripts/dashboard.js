$(document).ready(function () {

    $.ajax({
        type: "POST",
        url: 'Dashboard/DashBoardcount',
        data: JSON.stringify({}),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        success: function (json) {
            debugger
            var values = json.DashBoardcount;
            var malecount = parseInt(values[0]);
            var femalecount = parseInt(values[0]);




// Data retrieved from https://netmarketshare.com/
// Build the chart
Highcharts.chart('container', {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: 'Gender Chart',
        align: 'left'
    },
    tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    accessibility: {
        point: {
            valueSuffix: '%'
        }
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: false
            },
            showInLegend: true
        }
    },
    series: [{
        name: 'Brands',
        colorByPoint: true,
        data: [{
            name: 'Male',
            y: malecount,
            sliced: true,
            selected: true
        }, {
            name: 'Female',
            y: femalecount
        
        }]
    }]
});
        }
    })

});
