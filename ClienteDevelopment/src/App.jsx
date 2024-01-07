import { useState, useEffect } from 'react'
import './index.css'
import { TaskCard } from './components/TaskCard';
import { DraggableCard } from './components/DraggableCard';
import { DropZone } from './components/DropZone';
import { Modal } from './components/Modal';
import { getTasks, postTask } from './api/taskController';
import { getTasksProjects, postTaskProject } from './api/tasksProjectController';
import { getProjects } from './api/projectsController';

function App() {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [project, setProject] = useState(0)
  const [projects, setProjects] = useState([])
  const [tasksDb, setTasksDb] = useState([]);
  const [tasksProjects, setTasksProjects] = useState([])
  const [pendants, setPendants] = useState([]);
  const [progress, setProgress] = useState([]);
  const [completed, setCompleted] = useState([]);
  const [count, setCount] = useState(0)
  
  const [projectsOption, setProjectsOption] = useState([])

  useEffect(() => {
    const getFetchData = async () => {
      try{
        // Consumiendo la tabla proyectos para hacer el select con los proyectos de la base de datos
        const data = await getProjects();
        setProjects(data)
        const projectsOptionsDB = data.map(proyecto => 
          (<option key={proyecto.idProyecto} value={proyecto.idProyecto}>{proyecto.nombreProyecto}</option>) 
        );
        setProjectsOption([<option key={0} value={0} disabled selected> Seleccione el projecto </option>])
        setProjectsOption(prevData => [
          ...prevData,
          projectsOptionsDB
        ]);
        // Consumiendo tareas para ordenar por proyecto
        // Si te da problemas, el metodo para revisar errores que conozco ahorita es hacer console.log 
        // a los data de las respuestas de la promise
        // El error mas feo que tuve fueron dos, intentar consumir del state y no de los data porque el state no se actualiza a tiempo
        // y que al momento de filtrar y con un map me devolvia un arreglo de arreglos y no de objetos, ademas que algunos elementos undefined
        // que hay que eliminar
        // Tal vez esto se arregle combinando adecuadamente .filter y .map
        // Se arreglo de una mejor forma asi y ya no se necesito gestionar el arreglo de arreglos volverle de objetos, ni los undefined
        // Corrijo, si hay que transformar del arreglo de arreglos a un arreglo de objetos.
        // Solo me salvo de los undefined pero si ahorro bastante logica de codigo
        const dataTasks = await getTasks();
        setTasksDb(dataTasks)

        const dataTaskProjects = await getTasksProjects();
        setTasksProjects(dataTaskProjects)

        const tempPendant = dataTaskProjects.
          filter( tp_filter => tp_filter.idProyecto == project).
          map(tp_map => dataTasks.filter(task => task.idTarea == tp_map.idTarea))

        const tempObjects =tempPendant.flat(1); // Aqui transformo del arreglo de arreglos a unos de objetos
        setPendants(tempObjects)

      }catch(error){
        console.error('Error fetching projects:', error)
      }
    }
    getFetchData()
  }, [count, project, isModalOpen]);

  const handleProjectSelect = e => {
    const { value } = e.target;
    setProject(value)
  }

  const handleOpenModal = () => {
    setIsModalOpen(true);
  }
  const handleCloseModal = () => {
    setIsModalOpen(false);
  }
  const handleAddTask = async (formDataTask, formDataTaskProject) => {
    // Realiza la solicitud utilizando fetch
    try{
      const dataTask = await postTask(formDataTask)
      console.log(`Tarea agregada exitosamente: ${dataTask}`);
      const dataTaskProject = await postTaskProject(formDataTaskProject)
      console.log(`Relacion tarea-proyecto agregada exitosamente: ${dataTaskProject}`);
    } catch (error) {
      console.error(`Error al agregar la tarea y la relacion tarea-proyecto: ${error}`)
    }
  }
  const handleDropProgress = async droppedCard => {
    // Aquí puedes manejar la lógica cuando se suelta una tarjeta
    const url = `http://localhost:5000/api/tarea/${droppedCard.idTarea}`;
    console.log(droppedCard.idTarea);
    const taskActualizada = {
      idTarea: droppedCard.idTarea, 
      nombreTarea: droppedCard.nombreTarea, 
      descripcion: droppedCard.descripcion, 
      estado: "En Progreso", 
      minutos: droppedCard.minutos, 
      horas: droppedCard.horas, 
      idPersona: droppedCard.idPersona,
      idPersonaNavigation: droppedCard.idPersonaNavigation,
      tareasProyectos: droppedCard.tareasProyectos,
    };
    const configuracionSolicitud = {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json', // Tipo de contenido JSON
      },
      body: JSON.stringify(taskActualizada) // Convierte los datos a formato JSON
    };
    // Realiza la solicitud utilizando fetch
    try {
      const response = await fetch(url, configuracionSolicitud);
  
      if (!response.ok) {
        throw new Error(`Error al actualizar la tarea. Código de estado: ${response.status}`);
      }
  
      const data = await response.json();
      console.log('Tarea actualizada exitosamente:', data);

      setTasksDb(data);
  
      const auxProgress = data.filter(t => t.estado === "En Progreso");
      setProgress(auxProgress);
  
      
    } catch (error) {
      console.error('Error al actualizar la tarea:', error);
      // Incrementar el contador
      setCount(prevCount => {
        console.log('Incrementando contador:', prevCount + 1);
        return prevCount + 1;
      });
    }
  };

  const handleDropCompleted = droppedCard => {
    // Aquí puedes manejar la lógica cuando se suelta una tarjeta
    const url = `http://localhost:5000/api/tarea/${droppedCard.idTarea}`;
    console.log(droppedCard.idTarea);
    const taskActualizada = {
      idTarea: droppedCard.idTarea, 
      nombreTarea: droppedCard.nombreTarea, 
      descripcion: droppedCard.descripcion, 
      estado: "Completada", 
      minutos: droppedCard.minutos, 
      horas: droppedCard.horas, 
      idPersona: droppedCard.idPersona,
      idPersonaNavigation: droppedCard.idPersonaNavigation,
      tareasProyectos: droppedCard.tareasProyectos,
    };
    const configuracionSolicitud = {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json', // Tipo de contenido JSON
      },
      body: JSON.stringify(taskActualizada) // Convierte los datos a formato JSON
    };
    // Realiza la solicitud utilizando fetch
    fetch(url, configuracionSolicitud)
    .then(response => {
    if (!response.ok) {
      throw new Error(`Error al actualizar la tarea. Código de estado: ${response.status}`);
    }
      return response.json();
    })
    .then(data => {
      console.log('Tarea actualizada exitosamente:', data);
      setTasksDb(data)
      const auxCompleted = data.filter(t => t.estado =="Completada");
      setCompleted(auxCompleted)
      
    })
    .catch(error => {
      console.error('Error al actualizar la tarea:', error);
      setCount(prevCount => {
        console.log('Incrementando contador:', prevCount + 1);
        return prevCount + 1;
      });
    });
  };

  return (
    <>
      <div className={`${isModalOpen ? 'hidden' : 'grid'}  grid-cols-8 gap-4 bg-sky-700`}>
        <div className="col-start-2 col-span-6">
          <h1 className='text-center text-2xl p-7 font-bold text-white'>Administrador de Tareas</h1>
        </div>
        <div className='col-start-2 col-span-2 mx-auto'>
          <select 
            name="proyectos" 
            id="proyectos"
            onChange={handleProjectSelect}
            value={project}
            className="mt-1  p-2 border border-gray-300 justify-center rounded-md w-72"
          >
            {projectsOption}
          </select>
        </div>
        <div className="col-start-7 col-span-1 justify-center">
          {project > 0 ?
            <button
            onClick={handleOpenModal}
            className="flex items-center p-2 bg-blue-500 text-white rounded font-bold hover:bg-blue-700"
          >
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6 text-white mr-2">
              <path fillRule="evenodd" d="M12 3.75a.75.75 0 0 1 .75.75v6.75h6.75a.75.75 0 0 1 0 1.5h-6.75v6.75a.75.75 0 0 1-1.5 0v-6.75H4.5a.75.75 0 0 1 0-1.5h6.75V4.5a.75.75 0 0 1 .75-.75Z" clipRule="evenodd" />
            </svg>
            Tarea
          </button> :
          <p>Elije un proyecto</p>}
        </div>
        <div className='grid grid-cols-subgrid col-start-2 col-span-6 gap-4 bg-sky-600 p-3'>
          <div className="col-start-2 col-span2">
            <h2 className="text-xl font-bold mb-2 text-center text-white">Tareas Pendientes</h2>
            {/* {pendants.map(task => (
              <DraggableCard key={task.idTarea} card={task} />
            ))} */}
            {
              pendants.length > 0 ? pendants.
                filter(pendant =>
                  pendant.estado == "Pendiente" ).
                map(p => (<DraggableCard key={p.idTarea} card={p} />))
              :
              (<p>No hay elementos aun</p>)
            }
          </div>
          <div className="col-start-4 col-span-2">
            <h2 className="text-xl font-bold mb-2 text-center text-white">Tareas En Progreso</h2>
              {/* {progress.map(p => (
                <DraggableCard key={p.idTarea} card={p} />
              ))} */}
              {
              pendants.length > 0 ? pendants.
                filter(pendant =>
                  pendant.estado == "En Progreso" ).
                map(p => (<DraggableCard key={p.idTarea} card={p} />))
              :
              (<p>No hay elementos aun</p>)
            }
              <DropZone onDrop={handleDropProgress} />
          </div>
          <div className="col-start-6 col-span-2">
            <h2 className="text-xl font-bold mb-2 text-center text-white">Tareas Completadas</h2>
              {/* {completed.map(p => (
                <DraggableCard key={p.idTarea} card={p} />
              ))} */}
              {
              pendants.length > 0 ? pendants.
                filter(pendant =>
                  pendant.estado == "Completada" ).
                map(p => (<DraggableCard key={p.idTarea} card={p} />))
              :
              (<p>No hay elementos aun</p>)
            }
              <DropZone onDrop={handleDropCompleted} />
          </div>
        </div>
      </div>
      {isModalOpen && <Modal onClose={handleCloseModal} onSubmit={handleAddTask} tasks={tasksDb} project={project} />}
    </>
  );
};

export default App
