import { Statement } from '@/app/signed/components/Statement';
import { ContentGroup } from '@/components/ContentGroup';

export default function StatementPage() {
    return (
        <ContentGroup.Container>
            <ContentGroup.Title>Extrato</ContentGroup.Title>
            <ContentGroup.Content>
                <Statement.DateMarker date="hoje" />
                <Statement.Card
                    time="11:54"
                    title="Alimentos"
                    description="Compras do mês"
                    valueAmount={758.99}
                />
                <Statement.Card
                    time="11:54"
                    title="Alimentos"
                    description="Compras do mês"
                    valueAmount={-758.99}
                />
                <Statement.DateMarker date="ontem" className="mt-12" />
                <Statement.Card
                    time="11:54"
                    title="Alimentos"
                    description="Compras do mês"
                    valueAmount={758.99}
                />
                <Statement.Card
                    time="11:54"
                    title="Alimentos"
                    description="Compras do mês"
                    valueAmount={-758.99}
                />
            </ContentGroup.Content>
        </ContentGroup.Container>
    );
}
