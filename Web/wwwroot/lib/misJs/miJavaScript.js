function confirmBorrar(Id, seHizoClick) {
    var confirmBorrar = 'BorrarSpan_' + Id;
    var confirmBorrarSpan = 'confirmarBorrarSpan_' + Id;

    if (seHizoClick) {
        $('#' + confirmBorrar).hide();
        $('#' + confirmBorrarSpan).show();
    } else {
        $('#' + confirmBorrar).show();
        $('#' + confirmBorrarSpan).hide();
    }
}