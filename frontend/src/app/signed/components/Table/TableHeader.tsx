import { ReactNode } from 'react';

interface TableHeaderProps {
    children: ReactNode;
}

export default function TableHeader({ children }: TableHeaderProps) {
    return (
        <thead>
            <tr className="px-16 py-6 border-b-gray-900 border-b-2">
                {children}
            </tr>
        </thead>
    );
}
