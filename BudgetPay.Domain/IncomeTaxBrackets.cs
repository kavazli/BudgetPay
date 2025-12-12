using System;

namespace BudgetPay.Domain;

public class IncomeTaxBrackets
{
    private readonly List<IncomeTaxBracket> _brackets;

    public IReadOnlyList<IncomeTaxBracket> Brackets => _brackets;

    public IncomeTaxBrackets(IEnumerable<IncomeTaxBracket> brackets)
    {
        if (brackets == null || !brackets.Any())
            throw new ArgumentException("At least one tax bracket must be provided.");

        // 1. MinAmount'a göre sırala
        _brackets = brackets.OrderBy(b => b.MinAmount).ToList();

        // 2. Çakışma kontrolü
        for (int i = 1; i < _brackets.Count; i++)
        {
            if (_brackets[i].MinAmount <= _brackets[i - 1].MaxAmount)
                throw new ArgumentException("Tax brackets cannot overlap.");
        }
    }

    public IncomeTaxBracket GetBracketFor(decimal income)
    {
        foreach (var bracket in _brackets)
        {
            if (income >= bracket.MinAmount && income <= bracket.MaxAmount)
            {
                return bracket;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(income),
            "Income falls outside configured brackets.");
    }

}
