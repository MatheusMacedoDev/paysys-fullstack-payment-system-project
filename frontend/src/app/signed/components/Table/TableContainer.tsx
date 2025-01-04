import { ReactNode } from 'react';

interface TableContainerProps {
    children: ReactNode;
}

export default function TableContainer({ children }: TableContainerProps) {
    return <table className="w-full table-auto mt-12">{children}</table>;
}
