import { useState } from 'react'

export const Modal = ({  onClose, onSubmit, tasks, project }) => {
  const [ formDataTask, setFormDataTask] = useState({
    idTarea: tasks.length + 1,
    nombreTarea: '', 
    descripcion: '', 
    estado: 'Pendiente', 
    minutos: 0,  
    horas: 0, 
    idPersona: null,
    idPersonaNavigation: null,
    tareasProyectos: [],
  });

  const [ formDataTaskProject, setFormDataTaskProject] = useState({
    idTareaProyecto: tasks.length + 1,
    idTarea: tasks.length + 1,
    idProyecto: Number(project),
    idProyectoNavigation: null,
    idTareaNavigation: null,
  });

  const handleSubmit = () => {
    console.log("proyecto elegido");
    console.log(project);
    console.log(formDataTask);
    console.log(formDataTaskProject);
    onSubmit(formDataTask, formDataTaskProject);
    onClose();
  } 

	const handleInputChange = e => {
		const { name, value }= e.target;
    setFormDataTask(prevData => ({
      ...prevData,
      [name]: name=="horas" ? 
                Number(value) : 
                name=="minutos" ?
                  Number(value) :
                  value ,
    }));
	};
  const handleKeyPress = (e) => {
    // Solo permitir números del 0 al 9 y borrar
    const pattern = /[0-9]|Backspace/;
    if (!pattern.test(e.key)) {
      e.preventDefault();
    }
  };
  

  const horasOptions = [];
  for (let i = 0; i <= 24; i++) {
    horasOptions.push(
      <option key={i} value={i}>
        {i}
      </option>
    );
  }

  const minutosOptions = [];
  for (let i = 0; i <= 60; i++) {
    minutosOptions.push(
      <option key={i} value={i}>
        {i}
      </option>
    );
  }

  return (
    <div className={`fixed inset-0 flex items-center justify-center z-50 bg-black opacity-80`}>
      {/* <div className="bg-white opacity-50 fixed inset-0"></div> */}
      <div className="bg-black opacity-100 rounded-lg p-8 max-w-md w-full">
        <span className="absolute top-4 right-4 cursor-pointer text-xl text-white" onClick={onClose}>&times;</span>
        <h2 className="text-2xl font-bold mb-4 text-white text-center">Agregar Tarea</h2>
        <form>
          <div className="mb-4">
            <label htmlFor="nombreTarea" className="block text-sm font-medium text-white">Nombre:</label>
            <input
              type="text"
              id="nombreTarea"
              name="nombreTarea"
              onChange={handleInputChange}
              value={formDataTask.nombreTarea}
              className="mt-1 p-2 border border-gray-300 rounded-md w-full"
            />
          </div>
          <div className="mb-6">
            <label htmlFor="descripcion" className="block text-sm font-medium text-white">Descripción:</label>
            <textarea
              id="descripcion"
              name="descripcion"
              onChange={handleInputChange}
              value={formDataTask.descripcion}
              className="mt-1 p-2 border border-gray-300 rounded-md w-full"
            ></textarea>
          </div>
          <div className="flex flex-row mb-6">
            <div className="mr-4 basis-1/2" >
              <label htmlFor="horas" className="block text-sm font-medium text-white">Horas:</label>
              <select
                id="horas"
                name="horas"
                onChange={handleInputChange}
                value={formDataTask.horas}
                className="mt-1 p-2 border border-gray-300 rounded-md w-full"
              >
                {horasOptions}
              </select>
            </div>
  
            <div className="ml-4 basis-1/2">
              <label htmlFor="minutos" className="block text-sm font-medium text-white">Minutos:</label>
              <select
                id="minutos"
                name="minutos"
                onChange={handleInputChange}
                value={formDataTask.minutos}
                className="mt-1 p-2 border border-gray-300 rounded-md w-full"
              >
                {minutosOptions}
              </select>
            </div>
          </div>
          <button
            type="button"
            onClick={handleSubmit}
            className="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600 focus:outline-none focus:ring focus:border-blue-300"
          >
            Agregar Tarea
          </button>
        </form>
      </div>
      
    </div>
  )
}
