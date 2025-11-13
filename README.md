# 🏷️ Barcode File Renamer (WPF)

Una aplicación de escritorio desarrollada en C# (WPF) para automatizar el procesamiento de imágenes que contienen códigos de barras. La herramienta lee el código de barras incrustado en cada imagen y renombra el archivo con el valor de dicho código, moviéndolo a una carpeta de destino especificada.

## ✨ Características Principales

* **Procesamiento por Lotes:** Procesa todas las imágenes de una carpeta de origen de una sola vez.
* **Lectura de Códigos de Barras:** Utiliza **ZXing.NET** para una lectura precisa de códigos 1D y 2D.
* **Renombrado Inteligente:** Renombra el archivo con el valor del código de barras.
* **Movimiento de Archivos:** Copia o mueve la imagen renombrada a una carpeta de destino.
* **Interfaz Gráfica (WPF):** Interfaz de usuario simple para la selección de carpetas y seguimiento del proceso.

## 🛠️ Requisitos del Sistema

* Sistema Operativo: Windows 10 o superior.
* .NET Runtime: .NET 8.0 Desktop Runtime.

## 🚀 Uso de la Aplicación

Sigue estos sencillos pasos para procesar tus imágenes:

1.  **Ejecutar la Aplicación:** Abre el archivo `AppRanameBarcode.exe` de la carpeta de publicación.
2.  **Seleccionar Origen:** Haz clic en **"Directorio Origen"** y selecciona la carpeta que contiene las imágenes con códigos de barras.
3.  **Seleccionar Destino:** Haz clic en **"Directorio Destino"** y elige dónde deseas guardar las imágenes renombradas.
4.  **Iniciar Procesamiento:** Haz clic en el botón **"Iniciar Proceso"**.
5.  **Revisión de Alertas:** Si no es posible leer el codigo de barras de la imagen te saldra una alerta donde podras escribir el valor del codigo de barras para que se tome en cuenta la imagen.
6.  **Revisar el Reporte:** Se mostrará un mensaje final indicando cuántas imágenes fueron procesadas con éxito y cuántas fallaron (por no tener un código legible o por errores de I/O).

## ⚙️ Configuración y Desarrollo

### Tecnología

* **Lenguaje:** C#
* **Framework:** .NET 8.0
* **Interfaz:** Windows Presentation Foundation (WPF)

### Dependencias (Librerías NuGet)

Este proyecto utiliza las siguientes librerías NuGet:

| Librería | Propósito |
| :--- | :--- |
| `ZXing.NET` | Lectura y decodificación de códigos de barras. |
| `System.IO` | Manejo de archivos, rutas y directorios. |
| `Microsoft.WindowsAPICodePack-Shell` | Para diálogos modernos de selección de carpetas. |
| `ZXing.Net.Bindings.Windows.Compatibility` | Para la lectura de y escritura de codigos de barras. |


### Cómo Compilar

1.  Abre la solución (`.sln`) en Visual Studio.
2.  Asegúrate de tener instalados los paquetes NuGet.
3.  Cambia la configuración a `Release`.
4.  Ve a **Compilar** > **Compilar Solución** (Build > Build Solution).

### Cómo Publicar (Para Distribución)

1.  Haz clic derecho en el proyecto en el Explorador de Soluciones.
2.  Selecciona **Publicar...**.
3.  Sigue el asistente de publicación para generar la carpeta ejecutable que puede ser distribuida.

## ⚠️ Manejo de Errores

El software está diseñado para manejar los siguientes errores comunes:

* **Código No Legible:** Si una imagen no contiene un código de barras o no es legible, se solicita que escriba el codigo de barra al usuario, si no se suministra el archivo no se copia y se salta (no se mueve).
* **Duplicados:** Si el código de barras leído ya existe como nombre de archivo en la carpeta de destino, se mostrará una advertencia y el archivo será saltado.
* **Rutas Inválidas:** La aplicación verifica que las carpetas de origen y destino existan antes de iniciar el proceso.

---
Creado por: Andersson Ibarra
