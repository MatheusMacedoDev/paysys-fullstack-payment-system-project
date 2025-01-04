import { ReactNode } from 'react';

interface TableDataBodyProps {
    children: ReactNode;
}

export default function TableDataBody({ children }: TableDataBodyProps) {
    return <tbody>{children}</tbody>;
}
