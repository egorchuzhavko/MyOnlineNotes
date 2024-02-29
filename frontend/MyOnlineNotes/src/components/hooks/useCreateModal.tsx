import { useState } from 'react';

export default function useCreateModal() {
  const [isCreateOpen, setisOpen] = useState(false);

  const toggleCreate = () => {
    setisOpen(!isCreateOpen);
  };

  return {
    isCreateOpen,
    toggleCreate,
  };
}
