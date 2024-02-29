interface ModalType {
  userId: string;
  note: INotesState;
  isOpen: boolean;
  toggle: () => void;
}
