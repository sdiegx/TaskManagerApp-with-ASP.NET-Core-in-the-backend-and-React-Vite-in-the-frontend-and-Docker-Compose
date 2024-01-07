const TAREAS_URL = "http://localhost:5000/api/tarea"

export const getTasks = async () =>{
	const configurationGetTasks = {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json'
		}
	}
  const response = await fetch(`${TAREAS_URL}`,configurationGetTasks);
	if (!response.ok) {
    throw new Error(`Error al obtener las tareas. Código de estado: ${response.status}`);
  }
  return response.json();
}

export const postTask = async formDataTask => {
	const configuracionSolicitudPost = {
		method: 'POST',
		headers: {
		  'Content-Type': 'application/json', // Tipo de contenido JSON
		},
		body: JSON.stringify(formDataTask) // Convierte los datos a formato JSON
	  };
	const response = await fetch(`${TAREAS_URL}`,configuracionSolicitudPost)
	if(!response.ok)
		throw new Error(`Error al agregar la tarea. Código de estado: ${response.status}`);
	return response.json()
	// return response
}