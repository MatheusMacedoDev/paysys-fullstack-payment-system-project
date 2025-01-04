import { ReactNode } from 'react';

interface TableDataProps {
    children: ReactNode;
}

export default function TableData({ children }: TableDataProps) {
    return <tr className="px-16 py-6">{children}</tr>;
}
