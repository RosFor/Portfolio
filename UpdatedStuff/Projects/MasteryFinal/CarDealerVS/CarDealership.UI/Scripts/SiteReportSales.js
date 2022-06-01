$(document).ready(function () {
                $("#searchForm").submit(function (e) {
                    search();
                    return false;
                });
            });

            function search() {
                var params;

                params = 'UserSearch=' + $('#UserSearch').val();
                params += '&FromDate=' + $('#FromDate').val();
                params += '&ToDate=' + $('#ToDate').val();
                $.ajax({
                    type: 'GET',
                    url: 'http://localhost:44396/api/Reports/ReportSales?' + params,
                    async: false,
                    cache: false,
                    success: function (results) {
                        $('#searchResults').empty();

                        $.each(results, function (index, sales) {
                            var html =
                                '<tr>' +
                                '<td>' + sales.UserEmail + '</td>' +
                                '<td>$' + sales.SalePurchasePrice.toFixed(2) + '</td>' +
                                '<td>' + sales.Vehicle.VehicleID + '</td>' + 
                                '</tr>';

                            $('#searchResults').append(html.toString());
                        });

                    },
                    error: function () {
                        alert('Search result not found!')
                    }
                });
            }
