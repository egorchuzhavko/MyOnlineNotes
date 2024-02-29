import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { NotesService } from '../../../services/Notes.service';
import useCreateModal from '../../hooks/useCreateModal';
import useModal from '../../hooks/useModal';
import MainpageContent from './content/MainpageContent';
import NoteItemPopup from './content/content-noteItem/modal/NoteItemPopup';
import CreateNoteModal from './create-note-modal/CreateNoteModal';
import MainpageHeader from './header/MainpageHeader';

const Mainpage = () => {
  const { isOpen, toggle } = useModal();
  const { isCreateOpen, toggleCreate } = useCreateModal();
  const location = useLocation();
  const userid = location.state.id;
  const userName = location.state.username;
  const [listNotes, setListNotes] = useState<INotesState[]>([]);
  const [currentNote, setCurrentNote] = useState<INotesState>(listNotes[0]);

  useEffect(() => {
    const fullfillNotes = async () => {
      const data = await NotesService.takeUserNotes(userid);
      setListNotes(data);
    };
    fullfillNotes();
  }, []);

  return (
    <div>
      <MainpageHeader username={userName} toggle={toggleCreate} />
      <MainpageContent
        listNotes={listNotes}
        setCurrentNote={setCurrentNote}
        toggle={toggle}
      />
      <NoteItemPopup
        userId={userid}
        note={currentNote}
        isOpen={isOpen}
        toggle={toggle}
      />
      <CreateNoteModal
        setNotes={setListNotes}
        userId={userid}
        isOpen={isCreateOpen}
        toggle={toggleCreate}
      />
    </div>
  );
};

export default Mainpage;
