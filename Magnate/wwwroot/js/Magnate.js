$(document).ready(function () {
    $('.menubody .tenanticonwrap[data-subtype="0"]').hide();
});

function LotClick(lotEle) {
    var lotwrap = $('.block[data-blocknum="' + lotEle.data('blocknum') + '"] .lotwrap[data-lotnum="' + lotEle.data('lotnum') + '"]');
    var blocknum = lotEle.data('blocknum');

    var selectedCompanyNum = $("input[name='radCompany']:checked").val();
    var selectedBuildingNum = $("input[name='radBuilding']:checked").val();
    var selectedTenantNum = 4 * (parseInt($('.menubody .tenanticonwrap.selected').data('type')) - 1) + parseInt($('.menubody .tenanticonwrap.selected').data('subtype')) + 1; // $("input[name='radTenant']:checked").val();
    var selectedInspectionNum = $("input[name='radInspect']:checked").val();
    
    var ownernum = parseInt(lotEle.find('.company').data('companynum'));
    var buildingnum = parseInt(lotEle.find('.building').data('buildingnum'));
    var hasBuilding = buildingnum > 0;
    var isAvailable = ownernum === 0 && lotEle.find('.modifier').length === 0;
    
    var userinput = CreateUserInput(lotEle);

    if (selectedCompanyNum && blocknum !== 0) {
        if (isAvailable) {
            // BUY
            userinput.companynum = selectedCompanyNum;
            userinput.salepoints = 1;
            Buy(lotwrap, userinput);
        }
        else if (ownernum > 0) {
            // SELL
            userinput.companynum = ownernum;
            Sell(lotwrap, userinput);
        }
        
        $("input[name='radCompany']").each(function () {
            $(this).prop('checked', false);
        });
    }
    else if (selectedBuildingNum && ownernum > 0) {
        // BUILD
        userinput.buildingnum = selectedBuildingNum;
        AddBuilding(userinput);
        $("input[name='radBuilding']").each(function () {
            $(this).prop('checked', false);
        });
    }
    else if (selectedTenantNum && hasBuilding && ownernum > 0) {
        // ATTRACT
        userinput.tenantnum = selectedTenantNum;
        userinput.blocknum = parseInt(lotEle.data('blocknum'));
        AddTenant(userinput);
        $('.menubody .tenanticonwrap').removeClass('selected');
        $("input[name='radTenant']").each(function () {
            $(this).prop('checked', false);
        });
    }
    else if (selectedInspectionNum) {
        // INSPECT
        $('#inspectionwrap').html(lotEle.html());
        //InspectLot(lotview);
        $("input[name='radInspect']").each(function () {
            $(this).prop('checked', false);
        });
    }




}
