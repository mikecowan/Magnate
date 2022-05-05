function BuildBlocks() {
    var Blocks = [];

    for (var i = 0; i <= 6; i++) {
        var block = {
            id: i,
            name: $('.block[data-blocknum="' + i + '"] .blockname span').text(),
            Lots: []
        };

        for (var j = 0; j < 9; j++) {
            var lotEle = $('.block[data-blocknum="' + i + '"]').find('.lot[data-lotnum="' + j + '"]');
            var lot = {
                id: j,
                Building: {
                    buildingNum: lotEle.find('.building').data('buildingnum'),
                    tenantCount: lotEle.find('.tenants').data('tenantcount'),
                    Tenants: []
                },
                lotOwner: lotEle.find('.company').data('companynum'),
                blocknum: i,
                dice: lotEle.find('.dice').data('dicecount'),
                AdjacencyMods: [],
                salePoints: lotEle.find('.sale').data('salepoints')
            };

            var tenantsDetailsEle = lotEle.find('.tenantDetails');
            tenantsDetailsEle.find('.singletenant').each(function () {
                var tenant = {
                    type: $(this).data('type'),
                    subtype: $(this).data('subtype')
                };

                lot.Building.Tenants.push(tenant);
            });

            lotEle.find('.modifierdetail').each(function () {
                var mod = {
                    id: $(this).data('modifierid')
                };

                lot.AdjacencyMods.push(mod);
            });

            block.Lots.push(lot);
        }

        Blocks.push(block);
    }

    return Blocks;
}

function CreateUserInput(lotEle) {
    var input = {
        blocknum: parseInt(lotEle.data('blocknum')),
        lotnum: parseInt(lotEle.data('lotnum')),
        tenantcount: parseInt(lotEle.find('.tenants').data('tenantcount')),
        dicecount: parseInt(lotEle.find('.dice').data('dicecount')),
        salepoints: parseInt(lotEle.find('.sale').data('salepoints')),
        companynum: parseInt(lotEle.find('.company').data('companynum')),
        buildingnum: parseInt(lotEle.find('.building').data('buildingnum')),
        tenantnum: 0,
        marketvalue: parseInt($('#marketslider').val()),
        previouscompany: 0
    };

    return input;
}
