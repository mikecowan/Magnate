function CreateNewGame(blockArray) {

    $.ajax({
        type: "POST",
        url: '/Magnate/CreateNewGame',
        data: { blockArray: blockArray },
        dataType: "html",
        cache: false,
        success: function (data) {
            $('.singlecompanyincome').html("$0k");
            $('#city').html(data);
        },
        fail: function (data) {
            var test = 1;
        }
    });
}


function Buy(element, userinput) {
    var input = {
        uim: userinput,
        Blocks: []
    };

    input.Blocks = BuildBlocks();

    $.ajax({
        type: "POST",
        url: '/Magnate/Buy',
        data: input,
        dataType: "html",
        cache: false,
        success: function (data) {
            element.html(data);

            element.find('.lot').on('click', function () {
                LotClick($(this));
            });
        },
        fail: function (data) {
            var test = 1;
        }
    });
}

function Sell(element, userinput) {
    var input = {
        uim: userinput,
        Blocks: []
    };

    input.Blocks = BuildBlocks();
    input.Blocks[userinput.blocknum].Lots[userinput.lotnum].lotOwner = 0;

    $.ajax({
        type: "POST",
        url: '/Magnate/Sell',
        data: input,
        dataType: "html",
        cache: false,
        success: function (data) {
            element.html(data);
            AdjustIncome(input);
            element.find('.lot').on('click', function () {
                LotClick($(this));
            });
        },
        fail: function (data) {
            var test = 1;
        }
    });
}

function AddBuilding(userinput) {
    var input = {
        uim: userinput,
        Blocks: []
    };

    input.Blocks = BuildBlocks();

    $.ajax({
        type: "POST",
        url: '/Magnate/AddBuilding',
        data: input,
        dataType: "html",
        cache: false,
        success: function (data) {
            var blockwrap = $('.blockwrap[data-blocknum="' + userinput.blocknum + '"]');
            blockwrap.html(data);

            blockwrap.find('.lot').each(function () {
                $(this).on('click', function () {
                    LotClick($(this));
                });
            });
        },
        fail: function (data) {
            var test = 1;
        }
    });
}

function AddTenant(userinput) {
    var input = {
        uim: userinput,
        Blocks: []
    };

    input.Blocks = BuildBlocks();

    $.ajax({
        type: "POST",
        url: '/Magnate/AddTenant',
        data: input,
        dataType: "html",
        cache: false,
        success: function (data) {
            $('#city').html(data);
            AdjustIncome(input);
        },
        fail: function (data) {
            var test = 1;
        }
    });

}

function AdjustIncome(input) {
    var lotEle = $('.block[data-blocknum="' + input.uim.blocknum + '"]').find('.lot[data-lotnum="' + input.uim.lotnum + '"]');
    input.Blocks[input.uim.blocknum].Lots[input.uim.lotnum].Building.Tenants = [];

    lotEle.find('.singletenant').each(function () {
        var tenant = {
            type: $(this).data('type'),
            subtype: $(this).data('subtype')
        };

        input.Blocks[input.uim.blocknum].Lots[input.uim.lotnum].Building.Tenants.push(tenant);
    });

    $.ajax({
        type: "POST",
        url: '/Magnate/AdjustIncome',
        data: input,
        dataType: "html",
        cache: false,
        success: function (data) {
            $('.companyincomewrap[data-companynum="' + input.uim.companynum + '"]').html(data);
        },
        fail: function (data) {
            var test = 1;
        }
    });
}

function InspectLot(userinput) {
    var input = {
        uim: userinput,
        Blocks: []
    };

    input.Blocks = BuildBlocks();

    $.ajax({
        type: "POST",
        url: '/Magnate/InspectLot',
        data: input,
        dataType: "html",
        cache: false,
        success: function (data) {
            $('#inspectionwrap').html(data);
        },
        fail: function (data) {
            var test = 1;
        }
    });
}
