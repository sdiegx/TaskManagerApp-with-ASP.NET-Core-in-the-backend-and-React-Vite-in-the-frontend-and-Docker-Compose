const TAREAS_URL = "http://localhost:5000/api/proyecto"

export const getProject = async (idProject) =>{
	const configurationGetProject = {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json'
		}
	}
  const response = await fetch(`${TAREAS_URL}/${idProject}`,configurationGetProject);
	if (!response.ok) {
    throw new Error(`Error al obtener las tareas. Código de estado: ${response.status}`);
  }
  return response.json();
}

export const getProjects = async () =>{
	const configurationGetProjects = {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json'
		}
	}
  const response = await fetch(`${TAREAS_URL}`,configurationGetProjects);
	if (!response.ok) {
    throw new Error(`Error al obtener las tareas. Código de estado: ${response.status}`);
  }
  return response.json();
}