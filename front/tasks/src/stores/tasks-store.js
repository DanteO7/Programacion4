import { create } from "zustand";
import { v4 as uuidv4 } from "uuid";
import { persist } from "zustand/middleware";

const handler = (set) => ({
  tasks: [],
  add: (text) => {
    console.log("Agrego la tarea: ", text);
    const task = {
      id: uuidv4(),
      text,
      completed: false,
    };
    return set(({ tasks }) => ({ tasks: [...tasks, task] }));
  },
  delete: (id) => {
    return set(({ tasks }) => ({ tasks: tasks.filter((t) => t.id != id) }));
  },
  complete: (id) => {
    return set(({ tasks }) => {
      const taskFound = tasks.find((t) => t.id == id);
      taskFound.completed = true;

      const updated = tasks.filter((t) => t.id != id);

      return { tasks: [...updated, taskFound] };
    });
  },
});

export const useTaskStore = create(persist(handler, { name: "tasks-storage" }));
