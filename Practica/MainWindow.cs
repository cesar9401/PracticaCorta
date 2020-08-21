using System;
using System.Collections.Generic;
using Gtk;
using Practica;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnAnalizarButtonClicked(object sender, EventArgs e)
    {
        String oracion = entradaText.Text;
        if (oracion.Equals(""))
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Ingresa una oracion para analizar");
            md.Run();
            md.Destroy();
        }
        else
        {
            Logica logic = new Logica();
            logic.setOracion(oracion);

            labelPalabras.Text = logic.Palabras();
            labelNumeros.Text = logic.Numeros();
            labelDecimales.Text = logic.Decimales();
            labelMonedas.Text = logic.Monedas();
            labelErrores.Text = logic.Errores();
        }
    }
}
