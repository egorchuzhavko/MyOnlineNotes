interface ModalTypeCreate {
  setNotes: React.Dispatch<React.SetStateAction<INotesState[]>>;
  userId: string;
  isOpen: boolean;
  toggle: () => void;
}
