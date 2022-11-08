
import { useEffect, useState } from 'react';
import { VoteListsService } from '../../services/voteListsService'
import { VoteList } from '@/app/shared/types/types';


export interface UseVoteListType {
    state: VoteList | null;
    setState: React.Dispatch<React.SetStateAction<VoteList | null>>;
    loadVoteList(id: string): Promise<void>;
    submitVotes(id: string, votedIds: string[], readedIds: string[], blockedIds: string[]): Promise<void>;
}

export function useVoteList(): UseVoteListType {
    const [state, setState] = useState<VoteList | null>(null);

    useEffect(() => {
        const paths = window.location.pathname.split("/");
        loadVoteList(paths[paths.length - 1]);
    }, []);

    async function loadVoteList(id: string) {
        try {
            const response = await VoteListsService.getById(id);
            const voteList = response as VoteList;
            setState(voteList);

        } catch (error) {
            console.log(error);
        }
    }

    async function submitVotes(id: string, votedIds: string[], readedIds: string[], blockedIds: string[]) {
        try {
            await VoteListsService.vote({
                id: id,
                votedIds,
                readedIds,
                blockedIds
            });
        } catch (error) {
            console.log(error);
        }
    }

    return { state, setState, loadVoteList, submitVotes };
}
