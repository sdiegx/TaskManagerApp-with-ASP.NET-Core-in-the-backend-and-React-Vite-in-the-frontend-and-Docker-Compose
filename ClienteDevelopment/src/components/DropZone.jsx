import React from 'react'
import { useDrop } from 'react-dnd'

export const DropZone = ({ onDrop }) => {
    const [{ isOver }, drop] = useDrop({
        accept: 'CARD',
				drop: item => onDrop(item.card),
				collect: monitor => ({
					isOver: !!monitor.isOver(),
				}),
    })
  return (
    <div
      ref={drop}
      className={`border-2 border-dashed p-8 ${
        isOver ? 'bg-gray-200' : 'bg-white'
      } h-24`}
    >
      {/* Drop Zone */}
    </div>
  )
}
