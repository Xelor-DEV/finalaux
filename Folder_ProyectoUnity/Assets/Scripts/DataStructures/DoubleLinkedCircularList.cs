using System;
public class ListaDobleEnlazada<T>
{
    Nodo Cabeza;
    private int longitud = 0;
    public int Longitud
    {
        get
        {
            return longitud;
        }
    }
    class Nodo
    {
        public T Valor { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }
        public Nodo(T valor)
        {
            this.Valor = valor;
            Siguiente = null;
            Anterior = null;
        }
    }
    public void InsertarNodoAlInicio(T valor)
    {
        if (Cabeza == null)
        {
            Nodo nuevoNodo = new Nodo(valor);
            Cabeza = nuevoNodo;
            longitud = longitud + 1;
        }
        else
        {
            Nodo nuevoNodo = new Nodo(valor);
            nuevoNodo.Siguiente = Cabeza;
            Cabeza.Anterior = nuevoNodo;
            Cabeza = nuevoNodo;
            longitud = longitud + 1;
        }
    }
    public void InsertarNodoAlFinal(T valor)
    {
        if (Cabeza == null)
        {
            InsertarNodoAlInicio(valor);
        }
        else
        {
            Nodo ultimoNodo = ObtenerUltimoNodo();
            Nodo nuevoNodo = new Nodo(valor);
            ultimoNodo.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = ultimoNodo;
            longitud = longitud + 1;
        }
    }
    private Nodo ObtenerUltimoNodo()
    {
        Nodo ultimoNodo = Cabeza;
        while (ultimoNodo.Siguiente != null)
        {
            ultimoNodo = ultimoNodo.Siguiente;
        }
        return ultimoNodo;
    }
    public void InsertarNodoPorPosicion(T valor, int posicion)
    {
        if (posicion == 0)
        {
            InsertarNodoAlInicio(valor);
        }
        else if (posicion == longitud - 1)
        {
            InsertarNodoAlFinal(valor);
        }
        else if (posicion >= longitud)
        {
            throw new Exception("El valor introduccido va mas alla de la longitud de la lista");
        }
        else
        {
            Nodo nodoPosicion = Cabeza;
            int iterador = 0;
            while (iterador < posicion)
            {
                nodoPosicion = nodoPosicion.Siguiente;
                iterador = iterador + 1;
            }
            Nodo nuevoNodo = new Nodo(valor);
            Nodo anteriorNodo = nodoPosicion.Anterior;
            anteriorNodo.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = anteriorNodo;
            nuevoNodo.Siguiente = nodoPosicion;
            nodoPosicion.Anterior = nuevoNodo;
            longitud = longitud + 1;
        }
    }
    public void ModificarAlInicio(T valor)
    {
        if (Cabeza == null)
        {
            throw new Exception("No existe ningun nodo.");
        }
        else
        {
            Cabeza.Valor = valor;
        }
    }
    public void ModificarAlFinal(T valor)
    {
        if (Cabeza == null)
        {
            ModificarAlInicio(valor);
        }
        else
        {
            Nodo ultimo = Cabeza;
            while (ultimo.Siguiente != null)
            {
                ultimo = ultimo.Siguiente;
            }
            ultimo.Valor = valor;
        }
    }
    public void ModificarNodoPorPosicion(T valor, int posicion)
    {
        if (posicion == 0)
        {
            ModificarAlInicio(valor);
        }
        else if (posicion == longitud - 1)
        {
            ModificarAlFinal(valor);
        }
        else if (posicion >= longitud)
        {
            throw new Exception("No existe esa posicion en la lista");
        }
        else
        {
            Nodo nodoPosicion = Cabeza;
            int iterador = 0;
            while (iterador < posicion)
            {
                nodoPosicion = nodoPosicion.Siguiente;
                iterador = iterador + 1;
            }
            nodoPosicion.Valor = valor;
        }
    }
    public T ObtenerNodoDelInicio()
    {
        if (Cabeza == null)
        {
            throw new Exception("La lista esta vacia");
        }
        else
        {
            return Cabeza.Valor;
        }
    }
    public T ObtenerNodoDelFinal()
    {
        if (Cabeza == null)
        {
            return ObtenerNodoDelInicio();
        }
        else
        {
            Nodo ultimo = Cabeza;
            while (ultimo.Siguiente != null)
            {
                ultimo = ultimo.Siguiente;
            }
            return ultimo.Valor;
        }
    }
    public T ObtenerNodoPorPosicion(int posicion)
    {
        if (posicion == 0)
        {
            return ObtenerNodoDelInicio();
        }
        else if (posicion == longitud - 1)
        {
            return ObtenerNodoDelFinal();
        }
        else if (posicion >= longitud)
        {
            throw new Exception("El valor introduccido va mas alla de la longitud de la lista");
        }
        else
        {
            Nodo nodoPosicion = Cabeza;
            int iterador = 0;
            while (iterador < posicion)
            {
                nodoPosicion = nodoPosicion.Siguiente;
                iterador = iterador + 1;
            }
            return nodoPosicion.Valor;
        }
    }
    public void EliminarAlInicio()
    {
        if (Cabeza == null)
        {
            throw new Exception("No hay elementos en la lista");
        }
        else
        {
            Nodo nuevaCabeza = Cabeza.Siguiente;
            if (nuevaCabeza != null)
            {
                nuevaCabeza.Anterior = null;
            }
            Cabeza.Siguiente = null;
            Cabeza = nuevaCabeza;
            longitud = longitud - 1;
        }
    }
    public void EliminarAlFinal()
    {
        if (Cabeza == null)
        {
            EliminarAlInicio();
        }
        else
        {
            Nodo ultimoNodo = ObtenerUltimoNodo();
            Nodo nuevoUltimoNodo = ultimoNodo.Anterior;
            ultimoNodo.Anterior = null;
            nuevoUltimoNodo.Siguiente = null;
            ultimoNodo = null;
            longitud = longitud - 1;
        }
    }
    public void EliminarNodoPorPosicion(int posicion)
    {
        if (posicion == 0)
        {
            EliminarAlInicio();
        }
        else if (posicion == longitud - 1)
        {
            EliminarAlFinal();
        }
        else if (posicion >= longitud)
        {
            throw new Exception("El valor introduccido va mas alla de la longitud de la lista");
        }
        else
        {
            Nodo nodoPosicion = Cabeza;
            int iterador = 0;
            while (iterador < posicion)
            {
                nodoPosicion = nodoPosicion.Siguiente;
                iterador = iterador + 1;
            }
            Nodo anteriorNodo = nodoPosicion.Anterior;
            Nodo siguienteNodo = nodoPosicion.Siguiente;
            anteriorNodo.Siguiente = siguienteNodo;
            siguienteNodo.Anterior = anteriorNodo;
            nodoPosicion.Anterior = null;
            nodoPosicion.Siguiente = null;
            nodoPosicion = null;
            longitud = longitud - 1;
        }
    }
    public T[] GetNodesInRange(int start, int end)
    {
        if (start < 0 || end >= longitud)
        {
            throw new IndexOutOfRangeException("Las posiciones deben estar dentro del rango de la lista.");
        }

        if (start > end)
        {
            throw new ArgumentException("La posición inicial debe ser menor o igual a la posición final.");
        }

        T[] nodesInRange = new T[end - start + 1];
        Nodo current = Cabeza;
        int index = 0;
        while (index < start)
        {
            current = current.Siguiente;
            index = index + 1;
        }
        for (int i = 0; i < nodesInRange.Length; ++i)
        {
            nodesInRange[i] = current.Valor;
            current = current.Siguiente;
        }

        return nodesInRange;
    }
}
