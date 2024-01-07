import React from 'react'
import { useDrag } from 'react-dnd'
// import { CommandLineIcon  } from '@heroicons/react/24/solid/CommandLineIcon'
// import { CheckCircleIcon } from '@heroicons/react/24/solid/CheckCircleIcon'
// import { CodeBracketIcon } from '@heroicons/react/24/solid/CodeBracketIcon'


export const DraggableCard = ({ card }) => {
	const { idTarea, nombreTarea, descripcion, estado, minutos, horas, idPersona } = card;
  const [{ isDragging }, drag] = useDrag({
		type: 'CARD',
		item: { card },
		collect: monitor => ({
			isDragging: !!monitor.isDragging(),
		}),
	});
	// bg-white cursor-move bg-white border border-gray-300 p-4 rounded-lg shadow-md m-4
  return (
    <div
      ref={drag}
      className={`border ${isDragging ? 'opacity-50' : ''} p-6 w-64 rounded-lg shadow-md m-2 bg-sky-300 `}
    >
			<h3 className="text-xl font-bold mb-2">{nombreTarea}</h3>
      {/* <p className="text-gray-700">ID: {idTarea}</p> */}
      {estado=="En Progreso" ? 
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6 text-gray-800">
        <path fillRule="evenodd" d="M2.25 6a3 3 0 0 1 3-3h13.5a3 3 0 0 1 3 3v12a3 3 0 0 1-3 3H5.25a3 3 0 0 1-3-3V6Zm3.97.97a.75.75 0 0 1 1.06 0l2.25 2.25a.75.75 0 0 1 0 1.06l-2.25 2.25a.75.75 0 0 1-1.06-1.06l1.72-1.72-1.72-1.72a.75.75 0 0 1 0-1.06Zm4.28 4.28a.75.75 0 0 0 0 1.5h3a.75.75 0 0 0 0-1.5h-3Z" clipRule="evenodd" />
      </svg>
       : 
        estado=="Completada" ? 
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6 text-gray-800">
        <path fillRule="evenodd" d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12Zm13.36-1.814a.75.75 0 1 0-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 0 0-1.06 1.06l2.25 2.25a.75.75 0 0 0 1.14-.094l3.75-5.25Z" clipRule="evenodd" />
      </svg>
       : 
       <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6 text-gray-800">
       <path fillRule="evenodd" d="M14.447 3.026a.75.75 0 0 1 .527.921l-4.5 16.5a.75.75 0 0 1-1.448-.394l4.5-16.5a.75.75 0 0 1 .921-.527ZM16.72 6.22a.75.75 0 0 1 1.06 0l5.25 5.25a.75.75 0 0 1 0 1.06l-5.25 5.25a.75.75 0 1 1-1.06-1.06L21.44 12l-4.72-4.72a.75.75 0 0 1 0-1.06Zm-9.44 0a.75.75 0 0 1 0 1.06L2.56 12l4.72 4.72a.75.75 0 0 1-1.06 1.06L.97 12.53a.75.75 0 0 1 0-1.06l5.25-5.25a.75.75 0 0 1 1.06 0Z" clipRule="evenodd" />
     </svg>
     }
      <p className="text-gray-700">Descripción: {descripcion}</p>
      {/* <p className="text-gray-700">Estado: {estado}</p> */}
      <p className="text-gray-700">Duración: {horas} horas {minutos} minutos</p>
      <p className="text-gray-700">ID de Persona: {idPersona}</p>
    </div>
  )
}
