import React from 'react'

export const TaskCard = ({task}) => {
  const { id, nombre, descripcion, estado, minutos, horas, idPersona } = task
  return (
    <div className="bg-white border border-gray-300 p-4 rounded-lg shadow-md m-4">
      <h3 className="text-xl font-bold mb-2">{nombre}</h3>
      <p className="text-gray-700">ID: {id}</p>
      <p className="text-gray-700">Descripción: {descripcion}</p>
      <p className="text-gray-700">Estado: {estado}</p>
      <p className="text-gray-700">Duración: {horas} horas {minutos} minutos</p>
      <p className="text-gray-700">ID de Persona: {idPersona}</p>
    </div>
  )
}
