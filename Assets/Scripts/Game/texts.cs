using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//no estara asociado a nigun objeto sera llamado de otros scripts
[System.Serializable]
public class Textos{
    //como minimo dos lineas de codigo y 6 maximo 
    [TextArea (2,6)]
    //contenedor de textos
    public string[] arrayTexts;
}
