
$(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "/Home/GetTotalVendas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Adicionando o somatório acumulado aos dados
                response.datasets[0].data = calculateCumulativeTotal(response.datasets[0].data);
                response.datasets[1].data = calculateCumulativeTotal(response.datasets[1].data);

                const lineChart = document.getElementById('lineChart').getContext('2d');

                new Chart(lineChart, {
                    type: 'line',
                    data: {
                        labels: response.labels,
                        datasets: response.datasets
                    },
                    options: {
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


