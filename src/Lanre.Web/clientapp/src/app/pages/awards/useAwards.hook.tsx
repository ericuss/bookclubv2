
import { useEffect, useState } from 'react';
import { VoteListsService } from '../../services/voteListsService'
import { Awards, VoteList } from '@/app/shared/types/types';


export interface UseVoteListType {
    state: Awards | null;
    setState: React.Dispatch<React.SetStateAction<Awards | null>>;
    loadAwards(id: string): Promise<void>;
}

export function useAwards(): UseVoteListType {
    const [state, setState] = useState<Awards | null>(null);

    useEffect(() => {
        const paths = window.location.pathname.split("/");
        loadAwards(paths[paths.length - 2]);
    }, []);

    async function loadAwards(id: string) {
        try {
            const response = await VoteListsService.getAward(id);
            setState(response);

        } catch (error) {
            console.log(error);
        }
    }

    return { state, setState, loadAwards };
}
