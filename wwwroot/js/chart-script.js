$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetTotalVendas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            response.datasets[0].data = calculateCumulativeTotal(response.datasets[0].data);
            response.datasets[1].data = calculateCumulativeTotal(response.datasets[1].data);

            const ctx = document.getElementById('lineChart').getContext('2d');

            const containerWidth = $('#grafico').width();

            new Chart(ctx, {
                type: 'line',
                data: response, 
                options: {
                    responsive: true,
                    maintainAspectRatio: false, 
                    scales: {
                        x: [{
                            type: 'category',
                            labels: response.labels,
                            scaleLabel: {
                                display: true,
                                labelString: 'Data'
                            }
                        }],
                        y: [{
                            ticks: {
                                beginAtZero: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'Quantidade/Valor Financeiro'
                            }
                        }]
                    }
                }
            });

            const chart = new Chart(ctx);
            chart.options.width = containerWidth;
            chart.update();
        },
        error: function (error) {
            console.log(error);
            alert('Ocorreu um erro ao buscar os dados. Por favor, tente novamente.');
        }
    });
});

function calculateCumulativeTotal(values) {
    let cumulativeTotal = 0;
    return values.map(value => cumulativeTotal += value);
}


