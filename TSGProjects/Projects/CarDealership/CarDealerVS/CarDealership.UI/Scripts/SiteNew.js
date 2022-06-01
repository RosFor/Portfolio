$(document).ready(function () {
                $("#searchForm").submit(function (e) {
                    search();
                    return false;
                });
            });

            function search() {
                var params;
                var imagePath = '../Images/';
                var detailsPathOLDANDDUMB = '@Url.Action("Details", "Inventory")/';
                var detailsPath = 'http://localhost:44396/Inventory/Details/';

                params = 'SearchTerm=' + $('#SearchTerm').val();
                params += '&MinPrice=' + $('#MinPrice').val();
                params += '&MaxPrice=' + $('#MaxPrice').val();
                params += '&MinYear=' + $('#MinYear').val();
                params += '&MaxYear=' + $('#MaxYear').val();
                $.ajax({
                    type: 'GET',
                    url: 'http://localhost:44396/api/Inventory/New?' + params,
                    async: false,
                    cache: false,
                    success: function (results) {
                        $('#searchResults').empty();

                        $.each(results, function (index, vehicle) {
                            var html =
                                '<div class="row" id="bordered">' +
                                '<div class="col-md-3"><p><strong>' + vehicle.VehicleYear + ' ' + vehicle.VehicleModel.Make.MakeName + ' ' + vehicle.VehicleModel.ModelName + '</strong></p>' +
                                '<p><img src="' + imagePath + vehicle.VehicleImageFile + '"/></p></div>' +
                                '<div class="col-md-3"><p><strong>Body Style: </strong>' + vehicle.Body.BodyStyle + '</p>' + '<p><strong>Transmission: </strong>' + vehicle.Transmission.TransmissionType + '</p>' + '<p><strong>Color: </strong>' + vehicle.Color.ColorName + '</p></div>' +
                                '<div class="col-md-3"><p><strong>Interior: </strong>' + vehicle.InteriorColor.InteriorColorName + '</p>' + '<p><strong>Mileage: </strong>' + vehicle.Mileage + '</p>' + '<p><strong>VIN #: </strong>' + vehicle.VinNumber + '</p></div>' +
                                '<div class="col-md-3"><p><strong>Sale Price: </strong>' + vehicle.SalePrice + '</p>' + '<p><strong>MSRP: </strong>' + vehicle.MSRP + '</p>' + '<a href="' + detailsPath + vehicle.VehicleID + '"><button class="btn btn-primary">Details</button></a></div>' +
                                '</div>';

                            $('#searchResults').append(html.toString());
                        });

                    },
                    error: function () {
                        alert('Search result not found!')
                    }
                });
            }
