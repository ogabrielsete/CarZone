﻿let aspectRatio = 2.5;

if (window.matchMedia("(max-width: 425px)").matches) {
    aspectRatio = 3;
    document.getElementById('grafico').style.width = '90%'; // Ajuste a largura do contêiner do gráfico
}

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetTotalVendas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Adicionando o somat�rio acumulado aos dados
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
                    aspectRatio: aspectRatio,
                    scales: {
                        x: {
                            type: 'category',
                            title: {
                                display: true,
                            }
                        },
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                            }
                        }
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
