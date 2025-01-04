import { ReactNode } from 'react';
import Line from '../Line';

interface TableTitleProps {
    children: ReactNode;
}

export default function TableTitle({ children }: TableTitleProps) {
    return (
        <div className="flex flex-col items-center gap-3">
            <h1 className="font-semibold text-xl text-gray-900 uppercase">
                {children}
            </h1>
            <Line className="w-[200px] h-[3px] bg-gray-900" />
        </div>
    );
}
