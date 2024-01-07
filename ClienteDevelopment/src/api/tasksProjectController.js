const TAREAS_URL = "http://localhost:5000/api/tareasProyecto"

export const getTasksProjects = async () =>{
	const configurationGetTasksProjects = {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json'
		}
	}
  const response = await fetch(`${TAREAS_URL}`,configurationGetTasksProjects);
	if (!response.ok) {
    throw new Error(`Error al obtener las tareas. Código de estado: ${response.status}`);
  }
  return response.json();
}

export const postTaskProject = async formDataTaskProject => {
	console.log("datos de relacion tarea-proyecto");
	console.log(formDataTaskProject);
	const configuracionSolicitudPost = {
		method: 'POST',
		headers: {
		  'Content-Type': 'application/json', // Tipo de contenido JSON
		},
		body: JSON.stringify(formDataTaskProject) // Convierte los datos a formato JSON
	  };
	const response = await fetch(`${TAREAS_URL}`,configuracionSolicitudPost)
	if(!response.ok)
		throw new Error(`Error al agregar la relacion tarea proyecto. Código de estado: ${response.status}`);
	return response.json()
}