
function SearchDatatables(table, modul) {

    switch (modul) {
        case "cabangres":
            //$("div#datacabangs_length").append('<span style="padding-left:500px;">' +
            //    '<select id="cari_by" class="form-control" style>' +
            //    '<option value="Default">Aktif</option>' +
            //    '<option value="ShowAll">Deaktif</option>' +
            //    '</select>')
            //    .append('<input type="text" name="search" value="" id="search" placeholder="Cari" class="form-control">');
     $("div#datacabangs_length").append (
        $('<span>').css({
            'padding-left': '600px',
            'margin-left' : '50px'
        }).append(
                  $('<select>').addClass('form-control').attr({
                      'id': 'cari_by'
                      ,
                        'style': 'width: 8%;'
                              }).append(
                      $('<option>').val('Default').text('Aktif'),
                      $('<option>').val('ShowAll').text('Deaktif')
                    )
                )               
        ).append(
          $('<input>').attr({
              'type': 'text',
              'name': 'search',
              'id': 'search',
              'placeholder': 'Cari',
              'style': 'width: 20%; margin-left: 10px;',
              
          }).addClass('form-control')
        );


            $('#search').on('keyup', function () {
                var cariby = $("#cari_by").val();
                var searchBy = $("#search").val();
                if (!cariby || cariby === null) {
                    $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
                }
                else {
                    $('#cari_by').hideBalloon();
                    table
                        .search(cariby + "#" + searchBy)
                        .draw();
                }
            });
            $('#cari_by').on('change', function () {
                $('#cari_by').hideBalloon();
                var cariby = $("#cari_by").val();
                var searchBy = $("#search").val("");
                if (!cariby || cariby === null) {
                    $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
                }
                else {
                    $('#cari_by').hideBalloon();
                    table
                        .search(cariby + "#")
                        .draw();
                }
            });


            break;

            //case "Cabang":
            //    $("div#listCabang_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="NamaCabang">Nama Cabang</option>' +
            //        '<option value="KodeCabang">Kode Cabang</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "GrupBank":
            //    $("div#listGrupBank_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="KodeGrup">Kode Grup</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "GrupVendor":
            //    $("div#listGrupVendor_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="KodeGrupVendor">Kode Grup Vendor</option>' +
            //        '<option value="NamaGrupVendor">Nama Grup Vendor</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "JurnalHeader":
            //    $("div#listJurnalHeader_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="NomorJurnal">Nomor Jurnal</option>' +
            //        '<option value="Keterangan">Keterangan</option>' +
            //        '<option value="BonDetail">Nomor Bon</option>' + 
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "DebitNoAkun":
            //    $("div#listDebitNoAkun_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="NoAkun">No Akun</option>' +
            //        '<option value="NamaAkun">Nama Akun</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "CreditNoAkun":
            //    $("div#listCreditNoAkun_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="NoAkun">No Akun</option>' +
            //        '<option value="NamaAkun">Nama Akun</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "IntercompanyNamaCabang":
            //    $("div#listIntercompanyNamaCabang_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="NamaCabang">Nama Cabang</option>' +
            //        '<option value="KodeCabang">Kode Cabang</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

            //case "Laporan":
            //    $("div#listLaporan_length").append('<span style="padding-left:650px;"></span>' +
            //        '<select id="cari_by">' +
            //        '<option value="NamaReport">Nama Laporan</option>' +
            //        '</select>')
            //        .append('<input type="text" name="search" value="" id="search" placeholder="Cari">');

            //    $('#search').on('keyup', function () {
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val();
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#" + searchBy)
            //                .draw();
            //        }
            //    });
            //    $('#cari_by').on('change', function () {
            //        $('#cari_by').hideBalloon();
            //        var cariby = $("#cari_by").val();
            //        var searchBy = $("#search").val("");
            //        if (!cariby || cariby === null) {
            //            $('#cari_by').showBalloon({ html: true, position: "left", contents: '<h6>Tidak Boleh Kosong</h>' });
            //        }
            //        else {
            //            $('#cari_by').hideBalloon();
            //            table
            //                .search(cariby + "#")
            //                .draw();
            //        }
            //    });

            //    break;

        default:
            break;
    }
}